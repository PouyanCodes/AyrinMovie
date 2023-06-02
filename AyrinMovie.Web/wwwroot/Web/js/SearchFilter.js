// this file for search filter on the main page and chaning tabs 

// Aside Search filter box and tabs changing
const SearchinFilters = document.querySelector('.search-filter');
const AsideTab = document.querySelector('.aside-tab');
const SerialUpdate = document.querySelector('.updates-video');
const SerialFilters = document.querySelector('.filters-tab');
const SerialsContainer = document.querySelector('#serials-upd');
const UpdateVideoTab = document.querySelector('.updates-video').lastElementChild,
    SearchFilterTab = document.querySelector('.filters-tab').lastElementChild;


function leftAsideFunction() {
    AsideTab.style.right = '0';
    SerialsContainer.classList.add('easeOutSer');
    SerialsContainer.classList.remove('easeInSer');
    UpdateVideoTab.style.color = '#f9f9f9';
    SearchFilterTab.style.color = '#bbc1c6';
    SearchinFilters.classList.remove('SearchFilterIn');
}

function rightAsideFunction() {
    AsideTab.style.right = '50%';
    SerialsContainer.classList.add('easeInSer');
    SerialsContainer.classList.remove('easeOutSer');
    UpdateVideoTab.style.color = '#bbc1c6';
    SearchFilterTab.style.color = '#f9f9f9';
    SearchinFilters.classList.add('SearchFilterIn');
}

SerialFilters.addEventListener('click', rightAsideFunction);
SerialUpdate.addEventListener('click', leftAsideFunction);

// Search Filter dropdown select box
const SearchBoxTitle = document.querySelectorAll('.SearchBoxTitle');

function toggleSearchItems() {
    if (this.nextElementSibling.classList.contains('minSB')) {
        this.nextElementSibling.classList.toggle('min-searchfilter-style');
    } else {
        this.nextElementSibling.classList.toggle('normal-searchfilter-style');
    }

    this.closest('.search-filter').querySelectorAll('.normal-searchfilter-style , .min-searchfilter-style').forEach(element => {
        if (element !== this.nextElementSibling) {
            element.classList.remove('normal-searchfilter-style');
            element.classList.remove('min-searchfilter-style');
        }
    });
}

SearchBoxTitle.forEach(a => {
    a.addEventListener('click', toggleSearchItems);
});
// Search Filter dropdown select box

// Mobile search filter 
const MobileSearchFilter = document.querySelector('#ArticlesSearchFilter');

function MobileSearchFilterFunction() {
    SearchinFilters.classList.add('SearchFilterInAbs');
    SearchinFilters.classList.add('SearchFilterInMobile');
    NavigationMask.style.display = 'block';
    NavigationMask.classList.add('BlackMaskMenu');
    NavigationMask.addEventListener('click', () => {
        SearchinFilters.classList.remove('SearchFilterInAbs');
        SearchinFilters.classList.remove('SearchFilterInMobile');
        NavigationMask.style.display = 'none';
    })
}

MobileSearchFilter.addEventListener('click', MobileSearchFilterFunction);

// close mobile search filter button
const CloseMobileSearchFilter = document.querySelector('.closeSearchFilter');

CloseMobileSearchFilter.addEventListener('click', () => {
    SearchinFilters.classList.remove('SearchFilterInAbs');
    SearchinFilters.classList.remove('SearchFilterInMobile');
    NavigationMask.style.display = 'none';
})
// Mobile search filter 

// Search filter catching by input values
const allRadios = document.querySelectorAll('.custom-radio input');

function catchInputVal() {
    this.parentNode.parentNode.parentNode.previousElementSibling.firstElementChild.textContent = this.value;
}

allRadios.forEach(radio => {
    radio.addEventListener('change', catchInputVal);
})
// Search filter catching by input values

// /////////////
// End