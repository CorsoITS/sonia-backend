const { Operatore } = require("../model/models/Operatore");


class OperatoreController {
    static async lista (req, res) {
        // console.log('trying operatore controller...')
        if (req.query.q) {
            if (!req.params) req.params = {};
            req.params.id = req.query.q;
            return OperatoreController.length(req, res);
        }

        let result = await Operatore.lista();
        return res.json(result);
    }
}

module.exports = {
    OperatoreController
}