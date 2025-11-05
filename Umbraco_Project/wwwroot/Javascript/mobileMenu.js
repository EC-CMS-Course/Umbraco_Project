//ALL JAVASCRIPT I FILEN GENERERAD AV CHATGPT5

document.addEventListener("DOMContentLoaded", function () {
    const toggleBtn = document.getElementById("menuToggle");
    const mobileMenu = document.getElementById("mobileMenu");

    if (!toggleBtn || !mobileMenu) return; // skydd ifall elementen inte finns

    // Se till att menyn är stängd från början
    mobileMenu.classList.add("hidden");
    toggleBtn.setAttribute("aria-expanded", "false");

    // Toggle vid klick på hamburgarikonen
    toggleBtn.addEventListener("click", (e) => {
        e.stopPropagation();
        mobileMenu.classList.toggle("hidden");

        const isExpanded = toggleBtn.getAttribute("aria-expanded") === "true";
        toggleBtn.setAttribute("aria-expanded", String(!isExpanded));
    });

    // Stäng när man klickar på en länk i menyn
    mobileMenu.querySelectorAll("a").forEach(link => {
        link.addEventListener("click", () => {
            mobileMenu.classList.add("hidden");
            toggleBtn.setAttribute("aria-expanded", "false");
        });
    });

    // Stäng när man klickar utanför menyn
    document.addEventListener("click", (e) => {
        const isClickInsideMenu = mobileMenu.contains(e.target);
        const isClickOnToggle = toggleBtn.contains(e.target);

        if (!isClickInsideMenu && !isClickOnToggle) {
            mobileMenu.classList.add("hidden");
            toggleBtn.setAttribute("aria-expanded", "false");
        }
    });
});
