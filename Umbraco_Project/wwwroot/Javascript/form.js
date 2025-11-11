// ALL JAVASCRIPTS-VALIDERING GENERERAD AV CHATGPT5 (modifierad för flera formulär)
document.addEventListener("DOMContentLoaded", () => {
    // hämta ALLA formulär som ska valideras
    const forms = document.querySelectorAll(".validate-form");

    // gemensamma regler för alla typer av formulär
    const validators = {
        Name: (value) => {
            if (!value.trim()) return "Name is required";
            return "";
        },
        Email: (value) => {
            if (!value.trim()) return "Email is required";
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
        },
        Question: (value) => {
            if (!value.trim()) return "Question is required";
            return "";
        },
    };

    forms.forEach((form) => {
        // visar fel i rätt span i just DET HÄR formuläret
        const showError = (fieldName, message) => {
            const span = form.querySelector(`[data-valmsg-for="${fieldName}"]`);
            if (span) {
                span.textContent = message;
                span.classList.toggle("text-red-500", !!message);
            }
        };

        const validateField = (input) => {
            const name = input.getAttribute("name");
            // om fältet inte har en validator, skippa
            if (!name || !validators[name]) return true;

            const message = validators[name](input.value);
            showError(name, message);

            if (message) {
                input.classList.add("border-red-400");
            } else {
                input.classList.remove("border-red-400");
            }

            return !message;
        };

        // realtidsvalidering
        form.querySelectorAll("input, select, textarea").forEach((el) => {
            el.addEventListener("input", () => validateField(el));
            el.addEventListener("blur", () => validateField(el));
            el.addEventListener("change", () => validateField(el));
        });

        // vid submit: kolla allt i just det här formuläret
        form.addEventListener("submit", (e) => {
            let isValid = true;
            form.querySelectorAll("input, select, textarea").forEach((el) => {
                const ok = validateField(el);
                if (!ok) isValid = false;
            });

            if (!isValid) {
                e.preventDefault();
            } else {
                // spara scrollpositionen om du vill
                sessionStorage.setItem("scrollY", window.scrollY);
            }
        });
    });

    // återställ scroll efter redirect/post
    const scrollY = sessionStorage.getItem("scrollY");
    if (scrollY) {
        window.scrollTo({ top: parseInt(scrollY, 10), behavior: "instant" });
        sessionStorage.removeItem("scrollY");
    }
});

