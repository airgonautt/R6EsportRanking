const EXPAND_TRANSITION_TIME = 600;

window.initializeTCGCard = (cardElement) => {
    if (!customElements.get("tcg-card")) {
        customElements.define("tcg-card", TCGCard); // Ensure the TCGCard is defined
    }
    console.log("Initialized card:", cardElement);
};

class TCGCard extends HTMLElement {
    constructor() {
        super();
        this.handleMouseEnter = this.handleMouseEnter.bind(this);
        this.handleMouseMove = this.handleMouseMove.bind(this);
        this.handleMouseLeave = this.handleMouseLeave.bind(this);
        this.handleTouchStart = this.handleTouchStart.bind(this);
        this.handleTouchMove = this.handleTouchMove.bind(this);
        this.handleTouchEnd = this.handleTouchEnd.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.handleResize = this.handleResize.bind(this);
        this.resetCardPosition = this.resetCardPosition.bind(this);
    }

    connectedCallback() {
        const shadow = this.attachShadow({ mode: "open" });

        // Card HTML structure
        shadow.innerHTML = `
            <div class="tcg-wrapper">
                <div class="tcg-display"></div>
            </div>
            <style>
                .tcg-wrapper {
                    perspective: 1000px;
                }
                .tcg-display {
                    transition: transform 300ms ease-out, opacity 300ms ease-out;
                    transform: rotateX(0) rotateY(0);
                    transform-origin: center;
                    background: #eee;
                    width: 200px;
                    height: 300px;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    font-size: 16px;
                    border-radius: 10px;
                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                    opacity: 0;
                }
                .tcg-display:hover {
                    opacity: 1;
                }
            </style>
        `;

        this.card = this.shadowRoot.querySelector(".tcg-display");
        this.wrapper = this.shadowRoot.querySelector(".tcg-wrapper");

        this.addEventListener("mouseenter", this.handleMouseEnter);
        this.addEventListener("mousemove", this.handleMouseMove);
        this.addEventListener("mouseleave", this.handleMouseLeave);
        this.addEventListener("touchstart", this.handleTouchStart);
        this.addEventListener("touchmove", this.handleTouchMove);
        this.addEventListener("touchend", this.handleTouchEnd);

        this.card.addEventListener("click", this.handleClick);
        window.addEventListener("resize", this.handleResize);
        this.initImage();
    }

    disconnectedCallback() {
        this.removeEventListener("mouseenter", this.handleMouseEnter);
        this.removeEventListener("mousemove", this.handleMouseMove);
        this.removeEventListener("mouseleave", this.handleMouseLeave);
        this.removeEventListener("touchstart", this.handleTouchStart);
        this.removeEventListener("touchmove", this.handleTouchMove);
        this.removeEventListener("touchend", this.handleTouchEnd);

        this.card.removeEventListener("click", this.handleClick);
        window.removeEventListener("resize", this.handleResize);
    }

    initImage() {
        const img = this.shadowRoot.querySelector(".tcg-card");
        if (img && img.complete) {
            img.style.opacity = "";
        } else if (img) {
            img.onload = () => (img.style.opacity = "");
        }
    }

    handleMouseEnter(e) {
        this.startInteraction(e.clientX, e.clientY);
    }

    handleMouseMove(e) {
        this.updateTransform(e.clientX, e.clientY);
    }

    handleMouseLeave() {
        this.endInteraction();
    }

    handleTouchStart(e) {
        const touch = e.touches[0];
        this.startInteraction(touch.clientX, touch.clientY);
    }

    handleTouchMove(e) {
        e.preventDefault();
        const touch = e.touches[0];
        this.updateTransform(touch.clientX, touch.clientY);
    }

    handleTouchEnd() {
        this.endInteraction();
    }

    handleClick() {
        this.expanded ? this.close() : this.expand();
    }

    handleResize() {
        if (this.expanded) this.centerCard(true);
    }

    startInteraction(clientX, clientY) {
        this.card.style.transition = "all 300ms ease-out";
        this.updateTransform(clientX, clientY);
    }

    updateTransform(clientX, clientY) {
        const rect = this.card.getBoundingClientRect();
        const xPercent = ((clientX - rect.left) / rect.width) * 100;
        const yPercent = ((clientY - rect.top) / rect.height) * 100;
        this.style.setProperty("--pointer-x", `${xPercent}%`);
        this.style.setProperty("--pointer-y", `${yPercent}%`);
    }

    endInteraction() {
        this.card.style.transition = "all 300ms ease-out";
        this.style.setProperty("--pointer-x", "50%");
        this.style.setProperty("--pointer-y", "50%");
    }

    expand() {
        this.expanded = true;
        this.centerCard();
    }

    close() {
        this.expanded = false;
    }

    centerCard() {
        // Adjust positioning logic for centering.
    }
}

// Initialization function
function initializeTCGCard(cardElement) {
    if (!customElements.get("tcg-card")) {
        customElements.define("tcg-card", TCGCard);
    }

    console.log("Initialized card:", cardElement);
}

// Example usage
document.addEventListener("DOMContentLoaded", () => {
    const cardElements = document.querySelectorAll("tcg-card");
    cardElements.forEach(cardElement => initializeTCGCard(cardElement));
});
