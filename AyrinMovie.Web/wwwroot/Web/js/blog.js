// this blog.js for flixmovie blog



// Start Here

// blog aside tabs for change tags section and most view section
const blogAsideTab = document.querySelector('.aside-tab');
const tagsTab = document.querySelector('#tags__cr');
const mostViewTab = document.querySelector('#most__view');
const blogSortAndTagsContainer = document.querySelector('.blog__sort__list__and__tags__container');
const mostViewContainer = document.querySelector('.most__view__container');

// for right aside tab on blog page
function tagAsideTab() {
    blogAsideTab.style.right = '0';
    blogSortAndTagsContainer.classList.remove('most__view__container');
    mostViewContainer.classList.remove('most__view__in');
}

if (tagsTab) {
    tagsTab.addEventListener('click', tagAsideTab);
}
// for right aside tab on blog page

// for left aside tab on blog page
function mostViewTabs() {
    blogAsideTab.style.right = '50%';
    mostViewContainer.classList.add('most__view__in');
    blogSortAndTagsContainer.classList.add('most__view__container');
}

if (mostViewTab) {
    mostViewTab.addEventListener('click', mostViewTabs)
}
// for left aside tab on blog page



// blog scroll top button 
const scrollTopButton = document.querySelector('#scroll-top-btn-blog');

const scrollTopBlogButton = () => {
    if (window.scrollY > 300) {
        scrollTopButton.classList.add('show');
    } else {
        scrollTopButton.classList.remove('show');
    }
}

window.addEventListener('scroll', scrollTopBlogButton);

const goTopBlogBtn = () => {
    if (scrollTopButton.classList.contains('show')) {
        window.scrollTo({ top: 0 })
    }
}

scrollTopButton.addEventListener('click', goTopBlogBtn);
// blog scroll top button 

// blog post related animation and button
const blogPostRelatedLink = document.querySelector('#blog-post-related-link');
const blogRelatedPosts = document.querySelectorAll('.related__posts');

const goToBlogPostRelated = () => {
    for (let i = 0; i < blogRelatedPosts.length; i++) {
        blogRelatedPosts[i].classList.add('blogPostAnimation');
        setTimeout(function () {
            blogRelatedPosts[i].classList.remove('blogPostAnimation');
        }, 800)
    }
}

if (blogPostRelatedLink) {
    blogPostRelatedLink.addEventListener('click', goToBlogPostRelated);
}
// blog post related animation and button


// blog articles images zoom effect 
const blogImages = document.querySelectorAll('[data-image-zoom="true"]');
const closeImageZoom = document.querySelectorAll('.close-img-zoom');

// add new class for images fixed on the window
function blogImageZoom() {
    this.classList.add('img-zoom-effect');
    this.classList.remove('img-zoom-effect-out');
    this.parentNode.classList.add('img-parent-node');
    this.parentNode.firstElementChild.classList.add('close-image-zoom-in');
    this.parentNode.firstElementChild.classList.remove('close-image-zoom-out');
    document.body.style.overflow = 'hidden';
}

blogImages.forEach(zoom => {
    zoom.addEventListener('click', blogImageZoom);
})

// click to close button and remove image effect back to the normal
function closeImageZoomFunction() {
    this.classList.add('close-image-zoom-out');
    this.parentNode.classList.remove('img-parent-node');
    this.parentNode.lastElementChild.classList.add('img-zoom-effect-out');
    document.body.style.overflow = 'auto';
}

closeImageZoom.forEach(closeZoomImages => {
    closeZoomImages.addEventListener('click', closeImageZoomFunction);
})

// //////////////////
// End

// blog.js for flixmovie blog page only linked to blog pages



