const { routerOperatore } = require("./operatore-router");
const { routerPersona } = require("./persona-router");

function ConnectRouter (app) {
    app.use('/operatore', routerOperatore);
    app.use('/persona', routerPersona);
}

module.exports = {
    ConnectRouter
};