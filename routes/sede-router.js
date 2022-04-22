const Router = require('express');
const { SedeController } = require('../controllers/SedeController');
const routerSede = Router();

// console.log('trying operatore router...')
routerSede.get('/', SedeController.lista);
routerSede.get('/:id', SedeController.get);
routerSede.post('/', SedeController.insert);
routerSede.put('/:id', SedeController.update);
routerSede.delete('/:id', SedeController.delete);

module.exports = {
    routerSede
}