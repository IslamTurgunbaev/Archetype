// ==========================================
// БАЗОВЫЕ ДАННЫЕ ПО УМОЛЧАНИЮ
// ==========================================
const defaultItems = [
    { id: 101, title: "60 Примогемов", type: "currency", price: 60, desc: "Камни Истока для совершения молитв.", media: "https://via.placeholder.com/250x180?text=60+Primogems" },
    { id: 102, title: "300+30 Примогемов", type: "currency", price: 300, desc: "Набор Камней Истока с бонусом.", media: "https://via.placeholder.com/250x180?text=330+Primogems" },
    { id: 1, title: "Скин: Дилюк (Лин Уэй)", type: "character", price: 1350, desc: "Эксклюзивный облик с уникальными эффектами.", media: "https://via.placeholder.com/250x180?text=Diluc+Skin" },
    { id: 2, title: "Скин: Кэ Цин", type: "character", price: 1280, desc: "Праздничный наряд Нефритового Равновесия.", media: "https://via.placeholder.com/250x180?text=Keqing+Skin" },
    { id: 3, title: "Кейс: Сокровища Аранар", type: "case", price: 200, desc: "Испытай удачу и выбей примогемы или редкий скин!", media: "https://via.placeholder.com/250x180?text=Aranara+Case" }
];

// Шансы с поддержкой точности до 0.001%
const defaultCasesConfig = {
    3: [
        { itemId: 101, chance: 60.000 },
        { itemId: 102, chance: 39.999 },
        { itemId: 1, chance: 0.001 } // Супер-редкий шанс 0.001%
    ]
};

const defaultWheelConfig = [
    { itemId: 101, chance: 50.000 },  
    { itemId: 102, chance: 34.999 },  
    { itemId: 1, chance: 0.001 }, // Редкий скин 0.001%
    { itemId: 2, chance: 5.000 },    
    { itemId: 3, chance: 10.000 }     
];

const topUpPacks = [
    { crystals: 60, priceRub: 99, bonus: "" },
    { crystals: 300, priceRub: 499, bonus: "+30 бонус" },
    { crystals: 980, priceRub: 1490, bonus: "+110 бонус" },
    { crystals: 1980, priceRub: 2990, bonus: "+260 бонус" },
    { crystals: 3280, priceRub: 4990, bonus: "+600 бонус" },
    { crystals: 6480, priceRub: 9990, bonus: "+1600 бонус" }
];

// ==========================================
// ИНИЦИАЛИЗАЦИЯ И ХРАНИЛИЩЕ
// ==========================================
function loadInitialData(key, fallback) {
    try {
        const item = localStorage.getItem(key);
        return item ? JSON.parse(item) : fallback;
    } catch (e) {
        return fallback;
    }
}

let items = loadInitialData('abm_items', defaultItems);
let wheelConfig = loadInitialData('abm_wheel_config', defaultWheelConfig);
let casesConfig = loadInitialData('abm_cases_config', defaultCasesConfig);
let registeredUsers = loadInitialData('abm_registered_users', []);
let currentUser = loadInitialData('abm_user', null);
let pendingCheckoutPack = null;

function escapeHTML(str) {
    if (typeof str !== 'string') return str;
    return str.replace(/[&<>'"]/g, tag => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', "'": '&#39;', '"': '&quot;' }[tag] || tag));
}

// Форматирование процентов для красивого вывода (до 3 знаков после запятой)
function formatChance(num) {
    return Number(parseFloat(num).toFixed(3));
}

// ==========================================
// НАВИГАЦИЯ И ОТОБРАЖЕНИЕ
// ==========================================
function showSection(sectionId) {
    document.querySelectorAll('.main-section').forEach(sec => sec.classList.add('hidden'));
    const targetSection = document.getElementById(sectionId);
    if (targetSection) targetSection.classList.remove('hidden');
    
    if (sectionId === 'catalog-section') renderCatalog('all');
    if (sectionId === 'cases-section') renderCases();
    if (sectionId === 'topup-section') renderTopUpPacks();
    if (sectionId === 'wheel-section') setupWheel();
    if (sectionId === 'admin-section') renderAdminPanel();
    if (sectionId === 'profile-section') updateProfileUI();
}

function renderCatalog(filter = 'all') {
    const container = document.getElementById('skins-container');
    if (!container) return;
    container.innerHTML = '';
    const filtered = items.filter(item => item.type !== 'case' && (filter === 'all' || item.type === filter));
    filtered.forEach(item => container.appendChild(createCardHTML(item)));
}

function renderCases() {
    const container = document.getElementById('cases-container');
    if (!container) return;
    container.innerHTML = '';
    items.filter(item => item.type === 'case').forEach(item => container.appendChild(createCardHTML(item)));
}

function renderTopUpPacks() {
    const container = document.getElementById('topup-packs-container');
    if (!container) return;
    container.innerHTML = '';
    topUpPacks.forEach(pack => {
        const card = document.createElement('div');
        card.className = 'card';
        card.innerHTML = `
            <h3>💎 ${pack.crystals} Кристаллов</h3>
            <p style="color: #a2e048;">${escapeHTML(pack.bonus)}</p>
            <div class="price">${pack.priceRub} ₽</div>
            <button class="buy-btn" onclick="openCheckoutModal(${pack.crystals}, ${pack.priceRub})">Купить</button>
        `;
        container.appendChild(card);
    });
}

function filterSkins(type) { renderCatalog(type); }

function createCardHTML(item) {
    const card = document.createElement('div');
    card.className = 'card';
    const buttonText = item.type === 'case' ? 'Открыть кейс' : 'Купить';

    card.innerHTML = `
        <img src="${escapeHTML(item.media) || 'https://via.placeholder.com/250x180'}" alt="${escapeHTML(item.title)}">
        <h3>${escapeHTML(item.title)}</h3>
        <p style="font-size: 12px; color: #b3cca8;">${escapeHTML(item.desc)}</p>
        <div class="price">${item.price} 💎</div>
        <button class="buy-btn" onclick="handlePurchase(${item.id})">${buttonText}</button>
    `;
    return card;
}

function handlePurchase(itemId) {
    const item = items.find(i => i.id === itemId);
    if (!item) return;

    if (!currentUser) return openAuthModal('login');

    if (currentUser.balance < item.price) {
        return alert("Недостаточно Кристаллов! Перейдите в раздел 'Пополнение'.");
    }

    currentUser.balance -= item.price;

    if (item.type === 'case') {
        saveUserData();
        openCaseRoulette(item);
    } else {
        addItemToInventory(item);
        addHistoryItem(`Покупка: ${item.title}`);
        saveUserData();
        alert(`Товар "${item.title}" добавлен в ваш Инвентарь!`);
    }
}

// ==========================================
// 💳 СИСТЕМА ОПЛАТЫ И КАРТЫ
// ==========================================
function renderSavedCards() {
    const container = document.getElementById('saved-cards-list');
    if (!container) return;
    container.innerHTML = '';

    if (!currentUser || !currentUser.cards || currentUser.cards.length === 0) {
        container.innerHTML = '<p style="color: #8ba880; font-size: 13px;">Привязанных карт нет.</p>';
        return;
    }

    currentUser.cards.forEach((card, index) => {
        const row = document.createElement('div');
        row.className = 'card-item-row';
        row.innerHTML = `
            <span>💳 <b>${card.number}</b> (${card.exp})</span>
            <button class="btn-delete" onclick="removeCard(${index})">Удалить</button>
        `;
        container.appendChild(row);
    });
}

function removeCard(index) {
    if (!currentUser || !currentUser.cards) return;
    currentUser.cards.splice(index, 1);
    saveUserData();
    renderSavedCards();
}

function openCheckoutModal(crystals, priceRub) {
    if (!currentUser) return openAuthModal('login');
    
    pendingCheckoutPack = { crystals, priceRub };
    document.getElementById('checkout-details').innerHTML = `
        Пакет: <b>${crystals} Кристаллов</b><br>
        К оплате: <b class="gold-text">${priceRub} ₽</b>
    `;

    const savedSelect = document.getElementById('checkout-saved-card-select');
    savedSelect.innerHTML = '';

    if (currentUser.cards && currentUser.cards.length > 0) {
        currentUser.cards.forEach((card, idx) => {
            savedSelect.innerHTML += `<option value="${idx}">Карта ${card.number}</option>`;
        });
    } else {
        savedSelect.innerHTML = '<option value="">Нет привязанных карт</option>';
    }

    toggleCheckoutCardSelect();
    toggleModal('checkout-modal');
}

function toggleCheckoutCardSelect() {
    const method = document.getElementById('checkout-payment-method').value;
    const savedGroup = document.getElementById('checkout-saved-cards-group');
    const newGroup = document.getElementById('checkout-new-card-group');

    savedGroup.classList.toggle('hidden', method !== 'saved');
    newGroup.classList.toggle('hidden', method !== 'new');
}

function processPayment() {
    if (!pendingCheckoutPack || !currentUser) return;

    const method = document.getElementById('checkout-payment-method').value;

    if (method === 'saved') {
        if (!currentUser.cards || currentUser.cards.length === 0) {
            return alert("У вас нет привязанных карт! Выберите другой способ оплаты.");
        }
    } else if (method === 'new') {
        const num = document.getElementById('checkout-card-num').value.trim();
        const exp = document.getElementById('checkout-card-exp').value.trim();
        const cvc = document.getElementById('checkout-card-cvc').value.trim();

        if (num.length < 16 || exp.length < 4 || cvc.length < 3) {
            return alert("Заполните корректно данные банковской карты!");
        }
    }

    currentUser.balance += pendingCheckoutPack.crystals;
    addHistoryItem(`Оплата по карте: +${pendingCheckoutPack.crystals} 💎 (${pendingCheckoutPack.priceRub} ₽)`);
    saveUserData();

    toggleModal('checkout-modal');
    alert(`Оплата прошла успешно! Ваш баланс пополнен на ${pendingCheckoutPack.crystals} 💎.`);
    pendingCheckoutPack = null;
}

// ==========================================
// ИНВЕНТАРЬ
// ==========================================
function addItemToInventory(item) {
    if (!currentUser) return;
    if (!currentUser.inventory) currentUser.inventory = [];
    
    currentUser.inventory.push({
        invId: Date.now() + Math.random(),
        title: item.title,
        media: item.media,
        status: 'pending'
    });
}

function renderInventory() {
    const grid = document.getElementById('inventory-grid');
    if (!grid) return;
    grid.innerHTML = '';

    if (!currentUser.inventory || currentUser.inventory.length === 0) {
        grid.innerHTML = '<p style="color: #8ba880;">Инвентарь пуст.</p>';
        return;
    }

    currentUser.inventory.forEach(invItem => {
        const div = document.createElement('div');
        div.className = 'inventory-card';
        const isPending = invItem.status === 'pending';

        div.innerHTML = `
            <img src="${escapeHTML(invItem.media) || 'https://via.placeholder.com/100'}" alt="${escapeHTML(invItem.title)}">
            <h4 style="font-size: 13px; margin: 5px 0;">${escapeHTML(invItem.title)}</h4>
            <div class="status ${isPending ? 'status-pending' : 'status-done'}">
                ${isPending ? 'Готов к отправке' : 'Отправлено на UID'}
            </div>
            ${isPending 
                ? `<button class="small-btn" onclick="claimInventoryItem(${invItem.invId})" style="width:100%; font-size:11px;">Активировать</button>` 
                : ''}
        `;
        grid.appendChild(div);
    });
}

function claimInventoryItem(invId) {
    if (!currentUser.uid) return alert("Укажите и сохраните ваш Genshin Impact UID выше!");
    const item = currentUser.inventory.find(i => i.invId === invId);
    if (item) {
        item.status = 'claimed';
        addHistoryItem(`Запрос на отправку "${item.title}" на UID: ${currentUser.uid}`);
        saveUserData();
        alert(`Заявка принята! Товар "${item.title}" будет отправлен на UID ${currentUser.uid}`);
    }
}

// ==========================================
// 🎰 КЕЙСЫ И РУЛЕТКА (ТОЧНОСТЬ ДО 0.001%)
// ==========================================
let activeCase = null;
let wonCaseItem = null;

function openCaseRoulette(caseItem) {
    activeCase = caseItem;
    document.getElementById('roulette-case-title').innerText = `Кейс: ${caseItem.title}`;
    document.getElementById('spin-btn').disabled = false;
    document.getElementById('roulette-result').classList.add('hidden');
    
    generateRouletteItems();
    toggleModal('case-modal');
}

// Вычисление выигрыша с плавающей точкой высокой точности
function getWeightedCaseReward(caseId) {
    const rewards = casesConfig[caseId] || [];
    if (rewards.length === 0) return items[0]; 

    const totalChance = rewards.reduce((sum, r) => sum + parseFloat(r.chance), 0);
    let randomVal = Math.random() * totalChance;

    for (let r of rewards) {
        const currentChance = parseFloat(r.chance);
        if (randomVal < currentChance) {
            return items.find(i => i.id === r.itemId) || items[0];
        }
        randomVal -= currentChance;
    }
    return items[0];
}

function generateRouletteItems() {
    const track = document.getElementById('roulette-track');
    if (!track) return;
    track.style.transition = 'none';
    track.style.transform = 'translateX(0px)';
    track.innerHTML = '';

    wonCaseItem = getWeightedCaseReward(activeCase.id);

    for (let i = 0; i < 50; i++) {
        const randomItem = (i === 38) ? wonCaseItem : items[Math.floor(Math.random() * items.length)];
        const itemDiv = document.createElement('div');
        itemDiv.className = 'roulette-item';
        itemDiv.innerHTML = `<span>${escapeHTML(randomItem.title)}</span>`;
        track.appendChild(itemDiv);
    }
}

function spinCaseRoulette() {
    document.getElementById('spin-btn').disabled = true;
    const track = document.getElementById('roulette-track');
    const targetIndex = 38;
    const stopPosition = (targetIndex * 110) - 250;

    track.style.transition = 'transform 4s cubic-bezier(0.15, 0.9, 0.2, 1)';
    track.style.transform = `translateX(-${stopPosition}px)`;

    setTimeout(() => {
        const resElem = document.getElementById('roulette-result');
        resElem.innerText = `🎉 Выпало: ${wonCaseItem.title}!`;
        resElem.classList.remove('hidden');

        addItemToInventory(wonCaseItem);
        addHistoryItem(`Кейс "${activeCase.title}": Выпало -> ${wonCaseItem.title}`);
        saveUserData();
    }, 4000);
}

function closeCaseModal() { toggleModal('case-modal'); }

// ==========================================
// 🎡 КОЛЕСО ФОРТУНЫ (ТОЧНОСТЬ ДО 0.001%)
// ==========================================
let currentAngle = 0;
let isWheelSpinning = false;

function setupWheel() {
    drawWheel();
    checkWheelCooldown();
}

function drawWheel() {
    const canvas = document.getElementById('wheel-canvas');
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    const numSlices = wheelConfig.length;
    if (numSlices === 0) return;

    const sliceAngle = (2 * Math.PI) / numSlices;
    const colors = ['#1d3b2a', '#2d523b', '#182d22', '#365a43', '#1e382b', '#264734'];

    ctx.clearRect(0, 0, 400, 400);

    for (let i = 0; i < numSlices; i++) {
        const angle = currentAngle + i * sliceAngle;
        const item = items.find(k => k.id === wheelConfig[i].itemId);
        const title = item ? item.title : 'Приз';

        ctx.beginPath();
        ctx.fillStyle = colors[i % colors.length];
        ctx.moveTo(200, 200);
        ctx.arc(200, 200, 195, angle, angle + sliceAngle);
        ctx.lineTo(200, 200);
        ctx.fill();
        ctx.strokeStyle = '#a2e048';
        ctx.lineWidth = 1;
        ctx.stroke();

        ctx.save();
        ctx.translate(200, 200);
        ctx.rotate(angle + sliceAngle / 2);
        ctx.textAlign = "right";
        ctx.fillStyle = "#e2f0d9";
        ctx.font = "bold 12px Segoe UI";
        ctx.fillText(title, 180, 5);
        ctx.restore();
    }
}

function getWeightedRandomWheelIndex() {
    const totalChance = wheelConfig.reduce((sum, item) => sum + parseFloat(item.chance), 0);
    let randomVal = Math.random() * totalChance;

    for (let i = 0; i < wheelConfig.length; i++) {
        const currentChance = parseFloat(wheelConfig[i].chance);
        if (randomVal < currentChance) return i;
        randomVal -= currentChance;
    }
    return 0;
}

function spinWheel() {
    if (isWheelSpinning) return;
    if (!currentUser) return openAuthModal('login');

    const lastSpin = currentUser.lastWheelSpin || 0;
    const now = Date.now();
    const cooldown = 24 * 60 * 60 * 1000;

    if (now - lastSpin < cooldown) return alert("Вы уже крутили колесо сегодня!");

    isWheelSpinning = true;
    document.getElementById('spin-wheel-btn').disabled = true;

    const winningIndex = getWeightedRandomWheelIndex();
    const slices = wheelConfig.length;
    const sliceAngle = (2 * Math.PI) / slices;

    const extraRounds = 5 * 2 * Math.PI; 
    const targetAngle = extraRounds + (slices - winningIndex - 0.5) * sliceAngle;

    let start = null;
    const duration = 5000;

    function animateWheel(timestamp) {
        if (!start) start = timestamp;
        const progress = Math.min((timestamp - start) / duration, 1);
        const easeOut = 1 - Math.pow(1 - progress, 3);

        currentAngle = easeOut * targetAngle;
        drawWheel();

        if (progress < 1) {
            requestAnimationFrame(animateWheel);
        } else {
            isWheelSpinning = false;
            currentUser.lastWheelSpin = Date.now();
            
            const wonConfig = wheelConfig[winningIndex];
            const wonItem = items.find(i => i.id === wonConfig.itemId);

            if (wonItem) {
                addItemToInventory(wonItem);
                addHistoryItem(`Колесо Удачи: Выиграно -> ${wonItem.title}`);
                document.getElementById('wheel-result').innerText = `🎉 Вы выиграли: ${wonItem.title}!`;
            }

            document.getElementById('wheel-result').classList.remove('hidden');
            saveUserData();
            checkWheelCooldown();
        }
    }

    requestAnimationFrame(animateWheel);
}

function checkWheelCooldown() {
    const btn = document.getElementById('spin-wheel-btn');
    const timerElem = document.getElementById('cooldown-timer');
    if (!btn || !timerElem) return;

    if (!currentUser || !currentUser.lastWheelSpin) {
        btn.disabled = false;
        timerElem.innerText = "Доступно!";
        return;
    }

    const diff = (24 * 60 * 60 * 1000) - (Date.now() - currentUser.lastWheelSpin);

    if (diff <= 0) {
        btn.disabled = false;
        timerElem.innerText = "Доступно!";
    } else {
        btn.disabled = true;
        const hours = Math.floor(diff / 3600000);
        const mins = Math.floor((diff % 3600000) / 60000);
        const secs = Math.floor((diff % 60000) / 1000);
        timerElem.innerText = `${hours}ч ${mins}м ${secs}с`;
    }
}

// ==========================================
// ⚡ УПРАВЛЕНИЕ АДМИН-ПАНЕЛЬЮ
// ==========================================
function renderAdminPanel() {
    renderAdminItemsList();
    renderWheelAdminControls();
    renderCaseAdminControls();
}

function renderAdminItemsList() {
    const list = document.getElementById('admin-items-list');
    if (!list) return;
    list.innerHTML = '';
    items.forEach(item => {
        const row = document.createElement('div');
        row.className = 'admin-item-row';
        row.innerHTML = `
            <span><b>[${escapeHTML(item.type.toUpperCase())}]</b> ${escapeHTML(item.title)} — ${item.price} 💎</span>
            <div>
                <button class="btn-edit" onclick="openEditModal(${item.id})">Изменить</button>
                <button class="btn-delete" onclick="deleteItem(${item.id})">Удалить</button>
            </div>
        `;
        list.appendChild(row);
    });
}

function renderCaseAdminControls() {
    const caseSelect = document.getElementById('case-select-admin');
    const itemSelect = document.getElementById('case-item-select-admin');
    if (!caseSelect || !itemSelect) return;
    
    caseSelect.innerHTML = '';
    itemSelect.innerHTML = '';

    const cases = items.filter(i => i.type === 'case');
    cases.forEach(c => caseSelect.innerHTML += `<option value="${c.id}">${escapeHTML(c.title)}</option>`);

    const nonCases = items.filter(i => i.type !== 'case');
    nonCases.forEach(i => itemSelect.innerHTML += `<option value="${i.id}">${escapeHTML(i.title)}</option>`);

    // Настройка шага ввода step="0.001"
    const chanceInput = document.getElementById('case-item-chance-admin');
    if (chanceInput) {
        chanceInput.setAttribute('step', '0.001');
        chanceInput.setAttribute('min', '0.001');
        chanceInput.setAttribute('placeholder', 'Шанс % (напр. 0.001)');
    }

    renderCaseAdminRewards();
}

function renderCaseAdminRewards() {
    const caseSelect = document.getElementById('case-select-admin');
    if (!caseSelect) return;

    const caseId = Number(caseSelect.value);
    const list = document.getElementById('case-rewards-admin-list');
    if (!list) return;
    list.innerHTML = '';

    if (!caseId || !casesConfig[caseId]) {
        list.innerHTML = '<p style="color:#8ba880; font-size:12px;">В этом кейсе нет товаров.</p>';
        return;
    }

    casesConfig[caseId].forEach((rew, idx) => {
        const item = items.find(i => i.id === rew.itemId);
        const row = document.createElement('div');
        row.className = 'wheel-reward-row';
        row.innerHTML = `
            <span>${item ? escapeHTML(item.title) : 'Удален'} — <b>Шанс: ${formatChance(rew.chance)}%</b></span>
            <button class="btn-delete" onclick="removeRewardFromCase(${caseId}, ${idx})">Удалить</button>
        `;
        list.appendChild(row);
    });
}

function addRewardToCase() {
    const caseId = Number(document.getElementById('case-select-admin').value);
    const itemId = Number(document.getElementById('case-item-select-admin').value);
    const chance = parseFloat(document.getElementById('case-item-chance-admin').value);

    if (!caseId || !itemId || isNaN(chance) || chance <= 0) return alert("Заполните все поля корректно! Минимальный шанс: 0.001%");

    if (!casesConfig[caseId]) casesConfig[caseId] = [];
    casesConfig[caseId].push({ itemId, chance });

    localStorage.setItem('abm_cases_config', JSON.stringify(casesConfig));
    renderCaseAdminRewards();
    alert(`Предмет добавлен в кейс с шансом ${formatChance(chance)}%!`);
}

function removeRewardFromCase(caseId, idx) {
    casesConfig[caseId].splice(idx, 1);
    localStorage.setItem('abm_cases_config', JSON.stringify(casesConfig));
    renderCaseAdminRewards();
}

function renderWheelAdminControls() {
    const select = document.getElementById('wheel-item-select');
    if (!select) return;
    select.innerHTML = '';
    items.forEach(item => {
        select.innerHTML += `<option value="${item.id}">${escapeHTML(item.title)}</option>`;
    });

    const chanceInput = document.getElementById('wheel-item-chance');
    if (chanceInput) {
        chanceInput.setAttribute('step', '0.001');
        chanceInput.setAttribute('min', '0.001');
        chanceInput.setAttribute('placeholder', 'Шанс % (напр. 0.001)');
    }

    const list = document.getElementById('wheel-rewards-list');
    if (!list) return;
    list.innerHTML = '';
    
    wheelConfig.forEach((wc, index) => {
        const item = items.find(i => i.id === wc.itemId);
        const row = document.createElement('div');
        row.className = 'wheel-reward-row';
        row.innerHTML = `
            <span>${item ? escapeHTML(item.title) : 'Удален'} — <b>Шанс: ${formatChance(wc.chance)}%</b></span>
            <button class="btn-delete" onclick="removeRewardFromWheel(${index})">Удалить</button>
        `;
        list.appendChild(row);
    });
}

function addRewardToWheel() {
    const itemId = Number(document.getElementById('wheel-item-select').value);
    const chance = parseFloat(document.getElementById('wheel-item-chance').value);

    if (isNaN(chance) || chance <= 0) return alert("Введите корректный шанс % (например: 0.001 или 5.5)");

    wheelConfig.push({ itemId, chance });
    localStorage.setItem('abm_wheel_config', JSON.stringify(wheelConfig));
    renderWheelAdminControls();
    drawWheel();
}

function removeRewardFromWheel(index) {
    wheelConfig.splice(index, 1);
    localStorage.setItem('abm_wheel_config', JSON.stringify(wheelConfig));
    renderWheelAdminControls();
    drawWheel();
}

function openEditModal(id) {
    const item = items.find(i => i.id === id);
    if (!item) return;

    document.getElementById('edit-item-id').value = item.id;
    document.getElementById('edit-item-title').value = item.title;
    document.getElementById('edit-item-type').value = item.type;
    document.getElementById('edit-item-price').value = item.price;
    document.getElementById('edit-item-desc').value = item.desc || '';
    document.getElementById('edit-item-image-url').value = item.media || '';

    toggleModal('edit-item-modal');
}

function deleteItem(id) {
    items = items.filter(i => i.id !== id);
    wheelConfig = wheelConfig.filter(w => w.itemId !== id);
    delete casesConfig[id];
    localStorage.setItem('abm_items', JSON.stringify(items));
    localStorage.setItem('abm_wheel_config', JSON.stringify(wheelConfig));
    localStorage.setItem('abm_cases_config', JSON.stringify(casesConfig));
    renderAdminPanel();
}

// ==========================================
// 🔑 АВТОРИЗАЦИЯ И ПРОФИЛЬ
// ==========================================
function openAuthModal(mode = 'login') {
    switchAuthTab(mode);
    toggleModal('auth-modal');
}

function switchAuthTab(tab) {
    const isLogin = tab === 'login';
    document.getElementById('tab-login-btn').classList.toggle('active', isLogin);
    document.getElementById('tab-register-btn').classList.toggle('active', !isLogin);
    document.getElementById('login-form').classList.toggle('hidden', !isLogin);
    document.getElementById('register-form').classList.toggle('hidden', isLogin);
}

function logout() {
    currentUser = null;
    localStorage.removeItem('abm_user');
    updateAuthUI();
    showSection('catalog-section');
}

function saveUserData() {
    if (currentUser) {
        localStorage.setItem('abm_user', JSON.stringify(currentUser));
        const idx = registeredUsers.findIndex(u => u.email === currentUser.email);
        if (idx !== -1) {
            registeredUsers[idx] = currentUser;
            localStorage.setItem('abm_registered_users', JSON.stringify(registeredUsers));
        }
    }
    updateAuthUI();
    updateProfileUI();
}

function addHistoryItem(text) {
    if (!currentUser) return;
    if (!currentUser.history) currentUser.history = [];
    currentUser.history.unshift(`[${new Date().toLocaleTimeString()}] ${text}`);
}

function updateAuthUI() {
    const loginBtn = document.getElementById('open-login-btn');
    const regBtn = document.getElementById('open-register-btn');
    const logoutBtn = document.getElementById('logout-btn');
    const userDisp = document.getElementById('user-display');
    const adminLink = document.getElementById('admin-link');

    if (!loginBtn) return;

    if (currentUser) {
        loginBtn.classList.add('hidden');
        regBtn.classList.add('hidden');
        logoutBtn.classList.remove('hidden');
        userDisp.classList.remove('hidden');
        document.getElementById('user-name').innerText = currentUser.name;
        document.getElementById('user-balance').innerText = currentUser.balance;
        adminLink.classList.toggle('hidden', currentUser.role !== 'admin');
    } else {
        loginBtn.classList.remove('hidden');
        regBtn.classList.remove('hidden');
        logoutBtn.classList.add('hidden');
        userDisp.classList.add('hidden');
        adminLink.classList.add('hidden');
    }
}

function updateProfileUI() {
    if (currentUser) {
        const profName = document.getElementById('prof-name');
        if (!profName) return;

        profName.innerText = currentUser.name;
        document.getElementById('prof-email').innerText = currentUser.email;
        document.getElementById('prof-balance').innerText = currentUser.balance;
        document.getElementById('prof-role').innerText = currentUser.role === 'admin' ? 'Администратор' : 'Пользователь';
        document.getElementById('prof-uid').value = currentUser.uid || '';

        renderInventory();
        renderSavedCards();

        const historyList = document.getElementById('purchase-history');
        historyList.innerHTML = currentUser.history && currentUser.history.length > 0
            ? currentUser.history.map(item => `<li>${escapeHTML(item)}</li>`).join('')
            : '<li>История пуста</li>';
    }
}

function saveUID() {
    if (currentUser) {
        currentUser.uid = document.getElementById('prof-uid').value;
        saveUserData();
        alert("UID сохранен!");
    }
}

function toggleModal(modalId) {
    const modal = document.getElementById(modalId);
    if (!modal) return;
    modal.style.display = modal.style.display === 'flex' ? 'none' : 'flex';
}

// ==========================================
// 🚀 СОБЫТИЯ СТАРТА И ФОРМ
// ==========================================
document.addEventListener('DOMContentLoaded', () => {

    // Форма создания нового товара
    const adminForm = document.getElementById('admin-item-form');
    if (adminForm) {
        adminForm.addEventListener('submit', function(e) {
            e.preventDefault();
            const mediaUrl = document.getElementById('item-image-url').value.trim();
            const newItem = {
                id: Date.now(),
                title: document.getElementById('item-title').value.trim(),
                type: document.getElementById('item-type').value,
                price: Number(document.getElementById('item-price').value),
                desc: document.getElementById('item-desc').value.trim(),
                media: mediaUrl || 'https://via.placeholder.com/250x180?text=Genshin+Item'
            };

            items.push(newItem);
            localStorage.setItem('abm_items', JSON.stringify(items));
            this.reset();
            renderAdminPanel();
            alert("Успешно! Товар добавлен в каталог.");
        });
    }

    // Форма добавления карты
    const cardForm = document.getElementById('add-card-form');
    if (cardForm) {
        cardForm.addEventListener('submit', function(e) {
            e.preventDefault();
            if (!currentUser) return;

            const rawNum = document.getElementById('card-number-input').value.trim();
            const exp = document.getElementById('card-exp-input').value.trim();
            
            const maskedNum = "**** **** **** " + rawNum.slice(-4);

            if (!currentUser.cards) currentUser.cards = [];
            currentUser.cards.push({ number: maskedNum, exp });
            
            saveUserData();
            this.reset();
            toggleModal('add-card-modal');
            alert("Банковская карта успешно привязана!");
        });
    }

    // Форма редактирования товара
    const editForm = document.getElementById('edit-item-form');
    if (editForm) {
        editForm.addEventListener('submit', function(e) {
            e.preventDefault();
            const id = Number(document.getElementById('edit-item-id').value);
            const idx = items.findIndex(i => i.id === id);

            if (idx !== -1) {
                items[idx].title = document.getElementById('edit-item-title').value;
                items[idx].type = document.getElementById('edit-item-type').value;
                items[idx].price = Number(document.getElementById('edit-item-price').value);
                items[idx].desc = document.getElementById('edit-item-desc').value;
                items[idx].media = document.getElementById('edit-item-image-url').value;

                localStorage.setItem('abm_items', JSON.stringify(items));
                renderAdminPanel();
                toggleModal('edit-item-modal');
                alert("Изменения сохранены!");
            }
        });
    }

    // Форма авторизации
    const loginForm = document.getElementById('login-form');
    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            e.preventDefault();
            const email = document.getElementById('login-email').value.trim();
            const pass = document.getElementById('login-password').value;

            if (email === "admin@genshin.com" && pass === "admin123") {
                currentUser = { name: "Администратор", email: email, role: "admin", balance: 99999, history: [], inventory: [], cards: [], uid: "" };
                saveUserData();
                toggleModal('auth-modal');
                alert("Вы вошли как Администратор!");
                return;
            }

            const foundUser = registeredUsers.find(u => u.email === email && u.password === pass);
            if (foundUser) {
                currentUser = foundUser;
                saveUserData();
                toggleModal('auth-modal');
                alert(`С возвращением, ${currentUser.name}!`);
            } else {
                alert("Неверный Email или Пароль!");
            }
        });
    }

    // Форма регистрации
    const regForm = document.getElementById('register-form');
    if (regForm) {
        regForm.addEventListener('submit', function(e) {
            e.preventDefault();
            const name = document.getElementById('reg-name').value.trim();
            const email = document.getElementById('reg-email').value.trim();
            const pass = document.getElementById('reg-password').value;

            if (registeredUsers.some(u => u.email === email)) {
                return alert("Пользователь с таким Email уже существует!");
            }

            const newUser = {
                name: name,
                email: email,
                password: pass,
                role: "user",
                balance: 500,
                history: [`[${new Date().toLocaleTimeString()}] Бонус за регистрацию: +500 💎`],
                inventory: [],
                cards: [],
                uid: ""
            };

            registeredUsers.push(newUser);
            localStorage.setItem('abm_registered_users', JSON.stringify(registeredUsers));

            currentUser = newUser;
            saveUserData();
            toggleModal('auth-modal');
            alert(`Регистрация успешна! Вам начислено 500 💎 бонуса.`);
        });
    }

    // Инициализация интерфейса
    updateAuthUI();
    renderCatalog('all');
    setupWheel();
    setInterval(checkWheelCooldown, 1000);
});