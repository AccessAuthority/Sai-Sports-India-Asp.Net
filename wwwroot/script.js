// Get the navigation element
const nav = document.querySelector('nav');

// Get the offset position of the header (or any element you want to trigger the sticky effect)
const stickyPoint = nav.offsetTop;

window.onscroll = function() {
    // Check if the page has been scrolled past the sticky point
    if (window.pageYOffset > stickyPoint) {
        nav.classList.add('sticky'); // Add the sticky class when scrolled past the point
    } else {
        nav.classList.remove('sticky'); // Remove the sticky class when not scrolled past the point
    }
};


// Navigation Menu 
// JavaScript for toggling the menu visibility on mobile
const menuToggle = document.getElementById('mobile-menu');
const navLinks = document.getElementById('nav-links');

menuToggle.addEventListener('click', () => {
    navLinks.classList.toggle('active');
});

