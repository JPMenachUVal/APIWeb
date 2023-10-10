function getRandomElement(array) {
    return array[Math.floor(Math.random() * array.length)];
}

function getRandomColor() {
    const colors = ['#7A918D', '#302943', '#0000ff', '#864D8C', '#C77ECF', '#CF9C6B', '#8A3840', '#528593', '#529374', '#DBFEB8', '#93B1A7', '#80624F'];
    return getRandomElement(colors);
}

function getFortune() {
    const fortunes = [
        "Veo dinero en un futuro. Aunque no es tuyo.",
        "Si el mundo es un pa�uelo, �nosotros qu� somos?",
        "C�sate con alguien que sepa conversar ya que con el pasar de los a�os s�lo eso podr�n hacer.",
        "Conf�a en tu intuici�n.",
        "El amor de tu vida no puede escogerse a cara o cruz, la paciencia te llevar� hacia �l.",
        "Nuestro primero y �ltimo amor es, el amor propio.",
        "Aprendamos a valorar lo que tenemos y no lo que perdimos.",
        "El amor te llevar� hacia otra direcci�n.",
        "No puedo ayudarte, soy solo una galleta.",
        "Error 404: Galleta no encontrada",
        "Tomate tiempo para disfutar el presente",
        "CocaCola, siempre en los grandes eventos.",
        "404 fortuna no encontrada.",
        "!Ella lo sabe todo!",
        "Este mensaje miente.",
        "Si yo fuera t�, dejar�a de leer ahora mismo.",
        "La polic�a est� en camino !huye!",
        "Cuidado con la comida China hoy, puede que te enfermes.",
        "Ag�tese antes de usar.",
        "Este mensaje se auto-destruir� en cinco segundos."
    ];
    return getRandomElement(fortunes);
}

function randomBackgroundColor() {
    const colors = ['#516ead', '#283655', '#7A918D', '#302943', '#0000ff', '#864D8C', '#C77ECF', '#CF9C6B', '#8A3840', '#528593', '#529374', '#DBFEB8', '#93B1A7', '#80624F'];
    return getRandomElement(colors);
}

function openFortuneCookie() {
    const cookie = document.getElementById('fortune-cookie');
    const fortuneText = document.getElementById('fortune-text');
    const body = document.body;

    const randomColor = getRandomColor();
    const randomFortune = getFortune();

    cookie.style.backgroundColor = randomColor;
    fortuneText.textContent = randomFortune;
    fortuneText.style.color = getRandomColor();

    body.style.background = `linear-gradient(to right, ${randomBackgroundColor()}, ${getRandomColor()})`;
}

const fortuneCookie = document.getElementById('fortune-cookie');
fortuneCookie.addEventListener('click', () => {
    openFortuneCookie();
    fortuneCookie.style.transform = 'rotate(180deg)';
    setTimeout(() => {
        fortuneCookie.style.transform = 'rotate(0deg)';
    }, 300);
});