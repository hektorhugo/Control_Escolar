var SingletonFactory = (function () {
    function SingletonClass() {
        // ...
    }
    var instance;
    return {
        getInstance: function () {
            // check if instance is available
            if (!instance) {
                instance = new SingletonClass();
                delete instance.constructor; // or set it to null
            }
            return instance;
        }
    };
})();
