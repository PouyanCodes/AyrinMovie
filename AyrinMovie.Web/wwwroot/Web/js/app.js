// this file linked to every page on flixmovietheme

// context menu disabled for images
const allDocumentImages = document.querySelectorAll('img');
for (let i = 0; i < allDocumentImages.length; i++) {
    allDocumentImages[i].addEventListener('contextmenu', (event) => {
        event.preventDefault();
    })
}
// disabed something



// Start here app.js

// /// // /// // ///
// Sticky Header
const header = document.querySelector('header.header');
const ScrollUp = 'scrollUp';
const ScrollDown = 'scrollDown';
let LastScroll = 0;

window.addEventListener('scroll', () => {
    const currentScroll = window.pageYOffset;
    if (currentScroll <= 0) {
        header.classList.remove(ScrollUp);
        return;
    }
    if (currentScroll > LastScroll && !header.classList.contains(ScrollDown)) {
        header.classList.remove(ScrollUp);
        header.classList.add(ScrollDown);
    } else if (
        currentScroll < LastScroll && header.classList.contains(ScrollDown)
    ) {
        header.classList.remove(ScrollDown);
        header.classList.add(ScrollUp);
    }
    LastScroll = currentScroll;
})
// Sticky Header

// Search box Validation
const searchBoxForm = document.querySelector('#searchBoxForm');
const SearchFilter = document.querySelector('#Search-Filter');
const searchInput = document.getElementById('searchInput');

const SearchMoive = function (event) {
    event.preventDefault();
    if (searchInput.value == "" || searchInput.value == null) {
        document.title = "لطفا کلمه مورد نظر را وارد کنید";
        SearchFilter.click();
    } else {
        window.location = "/movies?movieTitle=" + searchInput.value;
    }
}

searchBoxForm.addEventListener('submit', SearchMoive);
// Search box Validation

// Cancel Search Btn
const cancelSearchIcon = document.querySelector('.cancelSearchIcon');
const Searchicon = document.querySelector('.searchbox-icon');

searchInput.addEventListener('focus', () => {
    cancelSearchIcon.classList.add('cancelSearchIconin');
    Searchicon.classList.add('SearchIconinOut');
});


searchInput.addEventListener('blur', () => {
    cancelSearchIcon.classList.remove('cancelSearchIconin');
    Searchicon.classList.remove('SearchIconinOut');
});
// Cancel Search Btn

// Mobile Menu Open And Close Styles
const MobileMenuIcon = document.querySelector('.mobile-menu-icon');
const MobileNavbar = document.querySelector('.mobile-navbar');
const NavigationMask = document.querySelector('.mask');

MobileMenuIcon.addEventListener('click', () => {
    if (MobileNavbar.style.display == 'block' && NavigationMask.style.display == 'block') {
        MobileNavbar.style.display = 'none';
        NavigationMask.style.display = 'none';
    } else {
        MobileNavbar.classList.remove('MobileBarClose');
        MobileNavbar.style.display = 'block';
        MobileNavbar.classList.add('MobileBarOpen')
        NavigationMask.style.display = 'block';
        NavigationMask.classList.add('BlackMaskMenu');

        NavigationMask.addEventListener('click', () => {
            MobileNavbar.classList.add('MobileBarClose');
            NavigationMask.style.display = 'none';
        })
    }
})
// Mobile Menu Open And Close Styles



// Mobile Menu item dropdown lists
const MobileMenuItems = document.querySelectorAll('.mobile-menu-title');

function toggleMenuItems() {
    this.classList.toggle('menu-active-item');
    this.classList.toggle('menu-active-item-bg');
    this.classList.toggle('mobile-menu-mines');
    this.nextElementSibling.classList.toggle('menu-item-show');
    this.closest('.mobile-navbar').querySelectorAll('.menu-active-item , .menu-item-show').forEach(element => {
        if (element !== this && element !== this.nextElementSibling) {
            element.classList.remove('menu-active-item', 'menu-active-item-bg', 'mobile-menu-mines', 'menu-item-show');
        }
    })
}

MobileMenuItems.forEach(li => {
    li.addEventListener('click', toggleMenuItems);
})
// Mobile Menu item dropdown lists

// Mobile search box form
const MobileSerachboxIcon = document.querySelector('.MobileSearchbox-icon-Container');
const StickySearchbox = document.querySelector('.desktop-searchbox');
const closeSearchBoxIcon = document.querySelector('.closeSearchBox');

MobileSerachboxIcon.addEventListener('click', () => {
    StickySearchbox.classList.add('StickySearchBoxIn');
    searchInput.focus();
})

closeSearchBoxIcon.addEventListener('click', () => {
    StickySearchbox.classList.remove('StickySearchBoxIn');
})
// Mobile search box form

// Pagination active buttons
const pagelines = document.querySelectorAll('.pagelines a');
const ActivePage = document.getElementsByClassName('active-page');

for (let i = 0; i < pagelines.length; i++) {
    pagelines[i].addEventListener('click', function (event) {
        ActivePage[0].className = ActivePage[0].className.replace('active-page', '');
        this.className += 'active-page';
    })
}
// Pagination active buttons

// Create SuccesMessage After newsletter validated
const SuccesEmailElm = document.createElement('div');
document.body.appendChild(SuccesEmailElm);
SuccesEmailElm.className = 'sussces-email-msg';
// Create SuccesMessage After newsletter validated

// Newsletter input Form Validate 
const EmailFormat = /^w+([.-]?w+)*@w+([.-]?w+)*(.w{2,3})+$/;
const NewsLetterInput = document.querySelector('#newsletter');
const SuccesEmailMsg = document.querySelector('.sussces-email-msg');
const NewsLetterForm = document.querySelector('#newsletter-inp');
const NewsLetterBtn = document.querySelector('.newsletter-btn');
const NewsLetterErr = document.querySelector('.newsletter-err');
const NewsLetterP = document.querySelector('.newsletter-err p');

function NewsForm(event) {
    event.preventDefault();
}

if (NewsLetterBtn) {
    NewsLetterBtn.addEventListener('click', function (EmailFormat) {
        if (NewsLetterInput.value.match(EmailFormat)) {
            SuccesEmailMsg.classList.add('sussces-email-msg-in');
            NewsLetterErr.classList.remove('newsletter-err-in');
            NewsLetterBtn.classList.add('checkinNewsLetter');
            SuccesEmailElm.innerHTML = `<p>تبریک شما ${NewsLetterInput.value} در خبرنامه عضو شدید.</p>`;
            setTimeout(function () {
                SuccesEmailMsg.classList.remove('sussces-email-msg-in');
            }, 3500)

            setTimeout(function () {
                SuccesEmailElm.remove();
            }, 5000)

            setTimeout(function () {
                NewsLetterBtn.classList.remove('checkinNewsLetter');
            }, 5000)

        } else if (NewsLetterInput.value == null || NewsLetterInput.value == "") {
            NewsLetterErr.classList.add('newsletter-err-in');
            NewsLetterP.innerHTML = 'لطفا فرم را پرنمایید';

        } else if (NewsLetterInput.value !== NewsLetterInput.value.match(EmailFormat)) {
            NewsLetterP.innerHTML = 'فرمت ایمیل نامعتبر می باشد';
            NewsLetterErr.classList.add('newsletter-err-in');

        } else {
            NewsLetterErr.classList.remove('newsletter-err-in');
        }
    })
}

if (NewsLetterForm) {
    NewsLetterForm.addEventListener('click', NewsForm);
}
// Newsletter input Form Validate 

// Footer navigation links for mobile devices dropdown menu
const FooterNavTitle = document.querySelectorAll('.footer-nav-link-title');

function FooterNavCollapse() {
    this.classList.toggle('footerTitleAfter');
    this.nextElementSibling.classList.toggle('footerNavList');
}

FooterNavTitle.forEach(h1 => {
    h1.addEventListener('click', FooterNavCollapse);
})
// Footer navigation links for mobile devices dropdown menu


// go top button on footer 
const scrollUpBtn = document.querySelector('#gotop');

if (scrollUpBtn) {
    scrollUpBtn.addEventListener('click', function (event) {
        event.preventDefault();
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    })
}
// go top button on footer 

// change page when clicked on button for loader page
function showloader(Loader, Elm) {
    let i, LoaderContent, LoaderElm;
    LoaderContent = document.getElementsByClassName('loaders-cr');
    for (i = 0; i < LoaderContent.length; i++) {
        LoaderContent[i].style.display = 'none';
    }
    document.getElementById(Loader).style.display = 'flex';
}
// change page when clicked on button for loader page

// get the buttons for loader page
const loaderButtons = document.querySelectorAll('.loader__btn__cr button');
const loaderButtonsClass = document.getElementsByClassName('active__loader__btn');

for (let x = 0; x < loaderButtons.length; x++) {
    loaderButtons[x].addEventListener('click', function (e) {
        loaderButtonsClass[0].className = loaderButtonsClass[0].className.replace('active__loader__btn', '');
        this.className += 'active__loader__btn';
    })
}
// get the buttons for loader page

// find default Loader page to click
const defLoaderPage = document.querySelector('#def');

if (defLoaderPage) {
    defLoaderPage.click();
}
// find default Loader page to click

// change paragraph text on 404 page when window resized
const errFirstP = document.querySelector('.err404__text p');

if (errFirstP) {
    function ChangePText() {
        if (window.innerWidth < 480) {
            errFirstP.innerHTML = 'به نظر می رسد شما از منطقه خارج شده اید.';
        } else {
            errFirstP.innerHTML = 'برای بازگشت به صفحه اصلی روی دکمه پایین کلیک کنید.';
        }
    }

    window.addEventListener('resize', ChangePText);
}
// change paragraph text on 404 page when window resized

// remove change footer bg btn
const changeFooterBg = document.querySelector('#change-footer-bg');

if (changeFooterBg) {
    changeFooterBg.style.display = 'none';
}
// remove change footer bg btn

// for top pages menu
const movieInfoButton = document.querySelectorAll('[data-movie-info]');

if (movieInfoButton) {
    function showInfo() {
        this.nextElementSibling.classList.add('movie-info-inner-open');
        this.nextElementSibling.lastElementChild.addEventListener('click', () => {
            this.nextElementSibling.classList.remove('movie-info-inner-open');
        })

        this.closest('.last__posts__container').querySelectorAll('.movie-info-inner-open').forEach(element => {
            if (element !== this && element !== this.nextElementSibling) {
                element.classList.remove('movie-info-inner-open');
            }
        })
    }
}

movieInfoButton.forEach(button => {
    button.addEventListener('click', showInfo)
})



// app.js global code for every page
// // // // // // // / /
// End

