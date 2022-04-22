const Router = require('express');
const { OperatoreController } = require('../controllers/OperatoreController');
const routerOperatore = Router();

// console.log('trying operatore router...')
routerOperatore.get('/', OperatoreController.lista);

module.exports = {
    routerOperatore
}