// panel authentication login page
const userLoginForm = document.getElementById('user-login')
const userName = document.getElementById('userid-input')
const userPassword = document.getElementById('userpsw-input')
const submitAuth = document.getElementById('submit-auth')
const formLegend1 = document.querySelectorAll('.form-legend')[0]
const formLegend2 = document.querySelectorAll('.form-legend')[1]
const sendingAnimation = document.querySelector('.sending-animation')

const authValidtionForm = (e) => {
    e.preventDefault()
}
userLoginForm.addEventListener('click', authValidtionForm)

const authValidtion = () => {
    if (userName && userPassword) {
        if (userName.value === '' && userPassword.value === '') {
            formLegend1.textContent = 'مقدار نام کاربری خالی میباشد'
            formLegend2.textContent = 'مقدار رمز عبور خالی میباشد'
        } 
    }
}
submitAuth.addEventListener('click', authValidtion)

const panelFormControl = document.querySelector('.panel-form-control')
const panelFormImg = document.querySelector('.panel-form-img')

window.addEventListener('load', () => {
    panelFormControl.classList.add('animation')
    panelFormImg.classList.add('animation')
})

// panel authentication reset password scripts
const resetPsw = document.querySelector('.reset-psw-input')
const reset_password = document.querySelector('#reset-password')
const formTitle = document.querySelector('.form-title')
let timer
let minutes = '00'
let second = 60

const resetPassword = () => {
    if (reset_password.value === '') {
        return false
    } else {
        formTitle.textContent = 'کد ارسال شد'
        let myint = setInterval(() => {
            second--
            timer.innerHTML = `<p>${minutes}:${second}</p>`

            if (second == 0) {
                timer.innerHTML = `<p>00:00</p>`
                clearInterval(myint)
            }
        }, 1000);

        timer = document.createElement('div')
        timer.className = 'countdown'

        resetPsw.innerHTML = `<div class="catch-code-container">
        <div class="catch-code-cr row">
            <div class="code-input"><input type="tel" max="9" min="0"></div>
            <div class="code-input"><input type="tel" max="9" min="0"></div>
            <div class="code-input"><input type="tel" max="9" min="0"></div>
            <div class="code-input"><input type="tel" max="9" min="0"></div>
            <div class="code-input"><input type="tel" max="9" min="0"></div>
            <div class="code-input"><input type="tel" max="9" min="0"></div>
        </div>
        </div>`
        const catchCodeCr = document.querySelector('.catch-code-container')
        catchCodeCr.appendChild(timer)

        submitAuth.disabled = true

        const allNumberInputs = document.querySelectorAll('.code-input input')

        for (let i = 0; i < allNumberInputs.length; i++) {
            allNumberInputs[i].addEventListener('keyup', () => {
                if (allNumberInputs[i].value === "") {
                    submitAuth.disabled = true
                } else {
                    submitAuth.disabled = false
                }
                if (allNumberInputs[i].value.length > 1) {
                    allNumberInputs[i].value = '';
                }
            })
        }
    }
}

setTimeout(() => {
    submitAuth.disabled = false
}, 60000)

submitAuth.addEventListener('click', resetPassword)

// view password button
const panelFormContainer = document.querySelector('.panel-form-container')
const beam = document.querySelector('.beam')
const viewPassword = document.querySelector('.view-password')

const viewPas = () => {
    viewPassword.classList.toggle('view-password-on')
    beam.classList.toggle('beam-on')

    if (userPassword.type === 'password') {
        userPassword.type = 'text'
    } else {
        userPassword.type = 'password'
    }
}

if (viewPassword) {
    viewPassword.addEventListener('click', viewPas)
}


// End