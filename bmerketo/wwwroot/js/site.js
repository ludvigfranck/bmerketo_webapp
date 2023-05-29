document.addEventListener('DOMContentLoaded', () => {
    const firstNameInput = document.getElementById('first-name');
    const lastNameInput = document.getElementById('last-name');
    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirm-password');
    const streetNameInput = document.getElementById('street-name');
    const postalCodeInput = document.getElementById('postal-code');
    const cityInput = document.getElementById('city');

    const namePattern = /^[A-Za-z]+$/;
    const emailPattern = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;
    const passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;

    const validateField = (input, pattern) => {
        const value = input.value;
        if (pattern.test(value)) {
            input.classList.remove('invalid');
        } else {
            input.classList.add('invalid');
        }
    };

    const validatePassword = () => {
        const password = passwordInput.value;
        const confirmPassword = confirmPasswordInput.value;
        if (password === confirmPassword) {
            passwordInput.classList.remove('invalid');
            confirmPasswordInput.classList.remove('invalid');
        } else {
            passwordInput.classList.add('invalid');
            confirmPasswordInput.classList.add('invalid');
        }
    };

    firstNameInput.addEventListener('input', () => {
        validateField(firstNameInput, namePattern);
    });

    lastNameInput.addEventListener('input', () => {
        validateField(lastNameInput, namePattern);
    });

    emailInput.addEventListener('input', () => {
        validateField(emailInput, emailPattern);
    });

    passwordInput.addEventListener('input', () => {
        validateField(passwordInput, passwordPattern);
        validatePassword();
    });

    confirmPasswordInput.addEventListener('input', () => {
        validatePassword();
    });

    streetNameInput.addEventListener('input', () => {
        validateField(streetNameInput, namePattern);
    });

    postalCodeInput.addEventListener('input', () => {
        validateField(postalCodeInput, /^\d{5}$/);
    });

    cityInput.addEventListener('input', () => {
        validateField(cityInput, namePattern);
    });
});
