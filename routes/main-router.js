const { routerOperatore } = require("./operatore-router");
const { routerPersona } = require("./persona-router");
const { routerSede } = require("./sede-router");

function ConnectRouter (app) {
    app.use('/operatore', routerOperatore);
    app.use('/persona', routerPersona);
    app.use('/sede', routerSede);
}

module.exports = {
    ConnectRouter
};