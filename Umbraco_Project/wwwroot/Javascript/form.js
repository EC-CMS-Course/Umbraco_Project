//document.addEventListener("submit", function (e) {
//    if (e.target.matches("form")) {
//        sessionStorage.setItem("scrollY", window.scrollY);
//    }
//});

//document.addEventListener("DOMContentLoaded", () => {
//    const scrollY = sessionStorage.getItem("scrollY");
//    if (scrollY) {
//        window.scrollTo({ top: parseInt(scrollY, 10), behavior: "instant" });
//        sessionStorage.removeItem("scrollY");
//    }
//})





//ALL JAVASCRIPTS-VALIDERING GENERERAD AV CHATGPT5

document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("callbackForm");

    if (form) {
        // våra regler – samma namn som i ViewModel
        const validators = {
            Name: (value) => {
                if (!value.trim()) return "Name is required";
                return "";
            },
            Email: (value) => {
                if (!value.trim()) return "Email is required";
                // samma regex som vi snackade om tidigare
                const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                if (!regex.test(value)) return "Please enter a valid email address";
                return "";
            },
            Phone: (value) => {
                if (!value.trim()) return "Phone is required";
                return "";
            },
            SelectedOption: (value) => {
                if (!value || value === "") return "Please select an option";
                return "";
            }
        };

        // helper för att skriva ut fel i rätt span
        const showError = (fieldName, message) => {
            const span = form.querySelector(`[data-valmsg-for="${fieldName}"]`);
            if (span) {
                span.textContent = message;
                // du kan lägga Tailwind-färg här
                span.classList.toggle("text-red-500", !!message);
            }
        };

        const validateField = (input) => {
            const name = input.getAttribute("name");
            if (!name || !validators[name]) return true; // fält vi inte validerar

            const message = validators[name](input.value);
            showError(name, message);

            if (message) {
                input.classList.add("border-red-400");
            } else {
                input.classList.remove("border-red-400");
            }

            return !message;
        };

        // realtidsvalidering på alla inputs/selects i formuläret
        form.querySelectorAll("input, select, textarea").forEach((el) => {
            el.addEventListener("input", () => validateField(el));
            el.addEventListener("blur", () => validateField(el));
            el.addEventListener("change", () => validateField(el));
        });

        // validera alla vid submit
        form.addEventListener("submit", (e) => {
            let isValid = true;

            form.querySelectorAll("input, select, textarea").forEach((el) => {
                const ok = validateField(el);
                if (!ok) isValid = false;
            });

            if (!isValid) {
                e.preventDefault();
            } else {
                // spara scrollpositionen om du skickar iväg formuläret
                sessionStorage.setItem("scrollY", window.scrollY);
            }
        });
    }

    // återställ scroll efter redirect/post
    const scrollY = sessionStorage.getItem("scrollY");
    if (scrollY) {
        window.scrollTo({ top: parseInt(scrollY, 10), behavior: "instant" });
        sessionStorage.removeItem("scrollY");
    }
});
