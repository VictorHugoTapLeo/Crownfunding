// script.js



function toggleMenu() {
    var menu = document.getElementById('menu');
    if (menu.classList.contains('active')) {
        menu.classList.remove('active');
        document.removeEventListener('click', closeMenuOutsideClick);
    } else {
        menu.classList.add('active');
        document.addEventListener('click', closeMenuOutsideClick);
    }
}

function closeMenuOutsideClick(event) {
    var menu = document.getElementById('menu');
    var button = document.querySelector('.menu-button');
    if (menu.classList.contains('active') && event.target !== menu && event.target !== button) {
        menu.classList.remove('active');
        document.removeEventListener('click', closeMenuOutsideClick);
    }
}
