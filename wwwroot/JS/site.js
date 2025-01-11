window.regionMap = {
    highlightRegion: (regionId, colorHex) => {
        const element = document.querySelector(`[data-region='${regionId}']`);
        if (element) {
            element.style.filter = `brightness(1) drop-shadow(0px 0px 5px ${colorHex})`;
        }
    },
    resetMapFilters: () => {
        const mapImages = document.querySelectorAll(".region-map");
        mapImages.forEach(image => {
            image.style.filter = "brightness(0)";
        });
    }
};