// this file worked for post likes and dislikes 
// and movei story toggle dropdown   
//  and post download box fullpage buttons 


// like and dislike for posts
const like = document.querySelector('#like__btn');
const dislike = document.querySelector('#dislike__btn');
const likeInner = document.querySelector('#likes');
const dislikeInner = document.querySelector('#dislikes');

likeInner.innerHTML = 221;
dislikeInner.innerHTML = 52;

const LikeBtn = () => {
    if (like.classList.contains("liked")) {
        like.classList.remove("liked");
        likeInner.innerHTML = 221;
    } else {
        like.classList.add("liked");
        dislike.classList.remove("disliked");
        likeInner.innerHTML = "😄";
        setTimeout(() => {
            likeInner.innerHTML = 222;
        }, 2000)
    }
}

const DislikeBtn = () => {
    if (dislike.classList.contains("disliked")) {
        dislike.classList.remove("disliked");
        dislikeInner.innerHTML = 52;
    } else {
        dislike.classList.add("disliked");
        like.classList.remove("liked");
        dislikeInner.innerHTML = '😡';
        setTimeout(() => {
            dislikeInner.innerHTML = 53;
        }, 2000);
    }
}

like.addEventListener('click', LikeBtn);
dislike.addEventListener('click', DislikeBtn);
// like and dislike for posts

// movie story dropdown for mobile devices
const movie__story = document.querySelectorAll('.movie__story__title');

function OpenMovieStory() {
    this.classList.toggle("movie__st__title");
    this.nextElementSibling.classList.toggle('movie__story__open');
}

movie__story.forEach(movie => {
    movie.addEventListener('click', OpenMovieStory);
})
// movie story dropdown for mobile devices

// Serials tab active button
function seasons(Season, elm) {
    let i, seasonContent, SeasonLink;
    seasonContent = document.getElementsByClassName("season")
    for (i = 0; i < seasonContent.length; i++) {
        seasonContent[i].style.display = "none";
    }

    const serials__tabs = document.querySelector(".buttons__cr").querySelectorAll("a")
    const ActivePagebtn = document.getElementsByClassName("active__serial__page")
    for (let x = 0; x < serials__tabs.length; x++) {
        serials__tabs[x].addEventListener("click", function (event) {
            ActivePagebtn[0].className = ActivePagebtn[0].className.replace('active__serial__page', '')
            this.className += "active__serial__page"
        })
    }

    document.getElementById(Season).style.display = "block";
    document.getElementById(Season).classList.add("Serials__dw__animation");
}

const defPage = document.getElementById("defOpen")

if (defPage) {
    defPage.click()
}
// Serials tab active button

// scrollto or scrollback btns on download box
const scrollToBtn = document.querySelector(".scrollTo")
const scrollBackBtn = document.querySelector(".scrollBack")
const DownloadBoxBtn = document.querySelector(".serial__or__film__btns")

if (scrollToBtn && scrollBackBtn) {
    scrollToBtn.onclick = () => {
        DownloadBoxBtn.scrollLeft += 200;
    }

    scrollBackBtn.onclick = () => {
        DownloadBoxBtn.scrollLeft -= 200;
    }
}

// add target blank for all download buttons
window.addEventListener('load', addTargetLink)

function addTargetLink() {
    const DownloadSerialsBtn = document.querySelectorAll(".download__serial__btn a");
    for (let i = 0; i < DownloadSerialsBtn.length; i++) {
        DownloadSerialsBtn[i].setAttribute("target", "_blank");
    }
}

// timer for screening movie
const screeningTimerContainer = document.querySelectorAll('.movie-timer')
const screenBadge = document.querySelectorAll('.screening-badge')

let screeningTimer = setInterval(updateTime, 1000)

function updateTime() {
    const screeningTime = new Date('Dec 30, 2021 22:04:25').getTime()

    let nowDate = new Date().getTime()
    let distance = screeningTime - nowDate

    let days = Math.floor(distance / (1000 * 60 * 60 * 24))
    let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
    let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60))
    let seconds = Math.floor((distance % (1000 * 60)) / (1000))

    if (days < 10) {
        days = '0' + days
    }
    if (hours < 10) {
        hours = '0' + hours
    }
    if (minutes < 10) {
        minutes = '0' + minutes
    }
    if (seconds < 10) {
        seconds = '0' + seconds
    }

    let timeString = `<div class="timeString"><span>${seconds}</span> 
    <span>${minutes}</span> <span>${hours}</span> <span>${days}</span></div>`

    screeningTimerContainer.forEach(timers => {
        timers.innerHTML = timeString
    })

    if (distance < 0) {
        clearInterval(screeningTimer)
        screenBadge.forEach(screeenBadge => {
            screeenBadge.style.display = 'none'
        })
    }
}


// video play button
const videoCr = document.querySelector('.video__container');
const Video = document.querySelector('video');
Video.removeAttribute('controls');

const VideoPlayButton = document.createElement('button');
VideoPlayButton.className = 'video-play-btn';

function VideoPlayBtn() {
    videoCr.appendChild(VideoPlayButton)
}

VideoPlayButton.addEventListener('click', PlayTrailer)

function PlayTrailer() {
    if (VideoPlayButton.style.display = 'block') {
        VideoPlayButton.style.display = 'none';
        Video.play();
        Video.setAttribute('controls', 'controls');
    }
}

VideoPlayBtn();

// /////////////////
// End