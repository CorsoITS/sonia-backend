const Router = require('express');
const { OperatoreController } = require('../controllers/OperatoreController');
const { checkIdOperatore } = require('../middlewares/check-id');
const routerOperatore = Router();

// console.log('trying operatore router...')
routerOperatore.get('/', OperatoreController.lista);
routerOperatore.get('/:id', checkIdOperatore, OperatoreController.get);
routerOperatore.post('/', OperatoreController.insert);
routerOperatore.put('/:id', checkIdOperatore, OperatoreController.update);
routerOperatore.delete('/:id', checkIdOperatore, OperatoreController.delete);

module.exports = {
    routerOperatore
}