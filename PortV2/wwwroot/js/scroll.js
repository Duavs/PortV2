
function scrollToTopOf(el) {
    if (!el) return;
    try {
        el.scrollTo({ top: 0, behavior: 'smooth' });
    } catch {
        el.scrollTop = 0;
    }
}

function registerScrollListener (elementId, dotNetHelper) {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener("scroll", () => {
        if (dotNetHelper) {
            const scrollValue = Math.floor(element.scrollTop || 0); // always integer
            dotNetHelper.invokeMethodAsync("OnScrollChanged", scrollValue);
        }
    });
}

function getScrollTopOf (element) {
    if (!element) return 0;
    return Math.floor(element.scrollTop || 0); // force integer
}