const Router = require('express');
const { SedeController } = require('../controllers/SedeController');
const { checkIdSede } = require('../middlewares/check-id');
const routerSede = Router();

// console.log('trying operatore router...')
routerSede.get('/', SedeController.lista);
routerSede.get('/:id', SedeController.get);
routerSede.post('/', checkIdSede, SedeController.insert);
routerSede.put('/:id', checkIdSede, SedeController.update);
routerSede.delete('/:id', checkIdSede, SedeController.delete);

module.exports = {
    routerSede
}