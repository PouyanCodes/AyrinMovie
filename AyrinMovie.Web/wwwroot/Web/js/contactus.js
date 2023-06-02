// this file for content us form validation 

// contact us form
const ContactUsForm = document.querySelector('#contact-us-form');
function ContactUsFormF(event) {
    event.preventDefault();
}

ContactUsForm.addEventListener('submit', ContactUsFormF);
// contact us form

// contact us form validation 
const ContactUsName = document.querySelector('#contact-us-name');
const ContactUsEmail = document.querySelector('#contact-us-email');
const ContactUsText = document.querySelector('#contact-us-text');

const ContactUsBtn = document.querySelector('#contactus-btn');

// contact us errors
const errBox1 = document.querySelectorAll('.err__box p')[0];
const errBox2 = document.querySelectorAll('.err__box p')[1];
const errBox3 = document.querySelectorAll('.err__box p')[2];

// contact us form validation
function ContactUsFormValidator(EmailFormat) {
    if (ContactUsName.value === "") {
        errBox1.style.display = "block";
    } else if (ContactUsName.value !== "") {
        errBox1.style.display = "none";
    }

    if (ContactUsEmail.value === "") {
        errBox2.style.display = "block";
    } else if (ContactUsEmail.value.match(EmailFormat)) {
        errBox2.style.display = "none";
    } else if (ContactUsEmail.value !== ContactUsEmail.value.match(EmailFormat)) {
        errBox2.innerHTML = 'فرمت ایمیل نامعتبر است.';
    }

    if (ContactUsText.value === "") {
        errBox3.style.display = "block";
    } else if (ContactUsText.value.length < 10) {
        errBox3.innerHTML = 'پیام ارسالی نمیتواند کمتر از ۱۰ حرف باشد.';
    } else if (ContactUsText.value !== "") {
        errBox3.style.display = "none";
    }
}

ContactUsBtn.addEventListener('click', ContactUsFormValidator);

// animation after valid forms
const SuccsesAnimation = document.querySelector('.sendSucceseFullAnimation');
const SuccsesMsg = document.querySelector('.succesfull__Msg');

function SuccesesContancUsMsg() {
    ContactUsAnimation = ContactUsName.value && ContactUsEmail.value && ContactUsText.value ? true : false;

    if (ContactUsAnimation === true) {
        SuccsesAnimation.classList.add('succses__Contact__in');
        setTimeout(function () {
            SuccsesAnimation.classList.remove('succses__Contact__in');
            SuccsesMsg.classList.add("succesfull__Msg__in");
            ContactUsName.value = "";
            ContactUsEmail.value = "";
            ContactUsText.value = "";
            setTimeout(function () {
                SuccsesMsg.classList.remove("succesfull__Msg__in");
            }, 4000);
        }, 4000)
    }
}

ContactUsBtn.addEventListener('click', SuccesesContancUsMsg);

// //////////////
// End

// this file for content us form validation 