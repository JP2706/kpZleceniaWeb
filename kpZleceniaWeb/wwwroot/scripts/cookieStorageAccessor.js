window.cookieFunctions = {
    set: function (key, value, domain) {
        document.cookie = `${key}=${value};max-age=31536000;path=/;domain=${domain}`;
    },

    get: function (key) {
        let name = key + "=";
        let ca = document.cookie.split(';');
        for (let i = 0; i < ca.length; i++) {
            let c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    },

    remove: function (key, domain) {
        document.cookie = `${key}="";expires=Thu, 01 Jan 1970 00:00:01 GMT;path=/;domain=${domain}`;
    }
}