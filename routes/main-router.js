const { routerOperatore } = require("./operatore-router");

function ConnectRouter (app) {
    app.use('/operatore', routerOperatore);
}

module.exports = {
    ConnectRouter
};