window.storage = {
    saveToSessionStorage: function (key, value) {
        sessionStorage.setItem(key, value);
    },
    getFromSessionStorage: function (key) {
        return sessionStorage.getItem(key);
    },
    removeFromSessionStorage: function (key) {
        sessionStorage.removeItem(key);
    }
};
