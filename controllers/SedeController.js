const { Sede } = require("../model/models/Sede");

class SedeController {
    static async lista (req, res) {
        // console.log('trying operatore controller...')
        if (req.query.q) {
            if (!req.params) req.params = {};
            req.params.id = req.query.q;
            return SedeController.length(req, res);
        }

        let result = await Sede.lista();
        return res.json(result);
    }

    static async get (req, res) {
        let result;
        if (! req.Sede) {
            result = await Sede.get(req.params.id);
        } else {
            result = req.Sede;
        }
        return res.json(result);
    }

    static async insert (req, res) {
        try {
            let np = new Sede();
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.citta) np.setCitta(req.body.citta);
            if (req.body.indirizzo) np.setIndirizzo(req.body.indirizzo);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }

    static async update (req, res) {
        try {
            let np = await Sede.get(req.params.id);
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.citta) np.setCitta(req.body.citta);
            if (req.body.indirizzo) np.setIndirizzo(req.body.indirizzo);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }

    static async delete (req, res) {
        try {
            if (await Sede.delete(req.params.id)) {
                res.status(200).send('ok');
            } else {
                res.status(400).send ("something went wrong");
            }
        // return res.json({
        //     message: 'successfully deleted'
        // }); 
        } catch {
            res.status(500).send ("Internal Server Error");
        }
    }
}

module.exports = {
    SedeController
}