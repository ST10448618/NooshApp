(function () {
    const CART_KEY = 'nooshCart';

    function getCart() {
        try { return JSON.parse(localStorage.getItem(CART_KEY)) || []; }
        catch { return []; }
    }

    function saveCart(cart) {
        localStorage.setItem(CART_KEY, JSON.stringify(cart));
        updateCartBadge();
    }

    function addToCart(item) {
        const cart = getCart();
        cart.push(item);
        saveCart(cart);
    }

    function removeFromCart(index) {
        const cart = getCart();
        cart.splice(index, 1);
        saveCart(cart);
    }

    function clearCart() {
        saveCart([]);
    }

    function updateCartBadge() {
        const badge = document.getElementById('cartCount');
        if (!badge) return;
        const count = getCart().length;
        badge.textContent = count;
        badge.style.display = count > 0 ? 'inline-flex' : 'none';
    }

    window.NooshCart = { getCart, addToCart, removeFromCart, clearCart, updateCartBadge };

    document.addEventListener('DOMContentLoaded', updateCartBadge);
})();