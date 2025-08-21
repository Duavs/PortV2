
function scrollToTopOf(el) {
    if (!el) return;
    try {
        el.scrollTo({ top: 0, behavior: 'smooth' });
    } catch {
        el.scrollTop = 0;
    }
}

function registerScrollListener (elementId, dotNetHelper)  {
    const element = document.getElementById(elementId);
    if (!element) return;

    element.addEventListener("scroll", () => {
        dotNetHelper.invokeMethodAsync("OnScrollChanged", element.scrollTop);
    });
}

function getScrollTopOf (element) {
    if (!element) return 0;
    return element.scrollTop;
}