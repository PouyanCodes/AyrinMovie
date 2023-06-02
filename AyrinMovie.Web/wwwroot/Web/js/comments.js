// this file for comment form validtion and creating comment



// Start here

// comments save on local storage 
window.addEventListener('load', function setTemplate() {
    document.getElementById('allComments').innerHTML = localStorage.getItem('template');
})

// set locacl storage comments
function setOnLocalStorage() {
    localStorage.setItem('template', document.getElementById('allComments').innerHTML);
}
// comments save on local storage 

// disable comment form submit button on local
const commentForm = document.querySelector("#post__cm__form");
function FormCm(event) {
    event.preventDefault();
}
commentForm.addEventListener("click", FormCm);
// disable comment form submit button on local

// comment form variables finding input and animation
const TextArea = document.querySelector('#add-comment-input');
const UserFName = document.querySelector('#auther');
const UserEmail = document.querySelector("#email");
const CommentAnimation = document.querySelector('.PostComment__Animation');
// comment form variables finding input and animation

// comment inputs when not validation show this errors
let UserNameErr = document.querySelector('#UserNameErr');
let UserEmailErr = document.querySelector('#UserEmailErr');
// comment inputs when not validation show this errors

// comment form submit button
const CommentSubmitBtn = document.querySelector('#submit__comment');
CommentSubmitBtn.disabled = true;
// comment form submit buttons

// add change event for text area on form inputs
TextArea.addEventListener("change", function () {
    CommentSubmitBtn.disabled = (TextArea.value === "");
})
// add change event for text area on form inputs

// username and email validation on post comment form
function SubmitCommentFormValidation() {
    if (UserFName.value === "" || UserFName.value === null) {
        UserNameErr.style.display = 'block';
        UserNameErr.textContent = 'نام کاربری نمیتواند خالی باشد';
        UserFName.style.borderColor = '#ff1414';
        UserFName.focus();
    } else if (UserFName.value.length < 4) {
        UserNameErr.textContent = 'نام کاربری نمیتواند کمتر از 4 حرف باشد';
        UserFName.focus();
    } else {
        UserNameErr.style.display = 'none';
        UserFName.style.borderColor = "";
    }

    if (UserEmail.value === "" || UserEmail.value === null) {
        UserEmailErr.style.display = 'block';
        UserEmailErr.textContent = 'ایمیل نمیتواند خالی باشد';
        UserEmail.style.borderColor = '#ff1414';
    } else {
        UserEmailErr.style.display = 'none';
        UserEmail.style.borderColor = "";
        CommentAnimation.classList.add("PostComment__Animation__in");

        setTimeout(function () {
            CommentAnimation.classList.remove("PostComment__Animation__in");
            setTimeout(() => {
                addComment();
                UserEmail.value = "";
                UserFName.value = "";
                TextArea.value = "";
                CommentSubmitBtn.disabled = true;
            }, 1000)
        }, 3500)
    }
}

CommentSubmitBtn.addEventListener("click", SubmitCommentFormValidation);
// username and email validation on post comment form

// all comments container
const allCommentsContainer = document.querySelector('#allComments');

// create comment element function
function addComment() {
    // IR Date for post comments
    let dateObject = new Date().toLocaleDateString('fa-IR');

    // random number for data comment id
    let random = Math.floor(Math.random() * 100);

    const CommentCr = document.createElement("div");
    CommentCr.setAttribute(`data-comment-id`, `${random}`);
    CommentCr.className = 'comment__cr';
    CommentCr.innerHTML =
        `<div class="WrapCmDiv">
        <div class="DateNameIcon__cr">
            <i class="fas fa-user Comment__user__icon"></i>
            <p class="Comment__user__name">${UserFName.value}</p>
            <span class="Comment__date__cr">${dateObject}</span>
        </div>
        <div class="LikeDislike__cr">
            <div  class="like__dislike__cm" title="پسندیدم">
                <i  class="fa fa-thumbs-up"></i>
                <span class="likes-count">0</span>
            </div>
            <div  class="like__dislike__cm" title="نپسندیدم">
            <i  class="fa fa-thumbs-down"></i>
            <span class="dislike-count">0</span>
            </div>
        </div>
    </div>
    <div class="CommentTextCr">
        <p>${TextArea.value}</p>
    </div> 
    <p class="replay__cm">نظر شما پس از تایید ادمین به نمایش در خواهد آمد.</p>`;

    // add to all comments container
    allCommentsContainer.appendChild(CommentCr);

    // call local storage function
    setOnLocalStorage();

    // return comment
    return CommentCr;
}
// create comment element function

// comment below button on footer
const ShowCommentBelow = document.querySelector('#addComment');
const ShowCommentBelowSpan = document.querySelector('#addComment span');
const ShowCommentBelowIcon = document.querySelector('#addComment i');

ShowCommentBelow.addEventListener('click', ShowCommentForm);

function ShowCommentForm() {
    if (ShowCommentBelowSpan.style.display == "none") {
        ShowCommentBelowSpan.style.display = "inline-block";
    } else {
        ShowCommentBelowSpan.style.display = "none";
    }
    commentForm.classList.toggle("comment__below__show");
    ShowCommentBelowIcon.classList.toggle('rotate__Cm__icon')
}

// submit button on footer
const submit__cm__footer = document.querySelector('#submit__comment__footer');

const SubmitCommentFooter = () => {
    ShowCommentBelow.click();
    window.location.href = "#comments__length";
    TextArea.focus();
}

if (submit__cm__footer) {
    submit__cm__footer.addEventListener("click", SubmitCommentFooter);
}
// // // // // // // / //
// End

// this file for create comments boxes have addComment function and comment form validtion

