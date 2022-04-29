const { Operatore } = require("../model/models/Operatore");


class OperatoreController {
    static async lista (req, res) {
        // console.log('trying operatore controller...')
        let result = await Operatore.lista();
        return res.json(result);
    }

    static async get (req, res) {
        let result = await Operatore.get(req.params.id);
        return res.json(result);
    }

    static async insert (req, res) {
        try {
            let np = new Operatore();
            if (req.body.ruolo) np.setRuolo(req.body.ruolo);
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.cognome) np.setCognome(req.body.cognome);
            if (req.body.username) np.setUsername(req.body.username);
            if (req.body.password) np.setPassword(req.body.password);
            if (req.body.sede_id) np.setSedeId(req.body.sede_id);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch (e) {
            res.status(500).send ('Internal Server Error');
            console.log(e);
        }
}

    static async update (req, res) {
        try {
            let np = await Operatore.get(req.params.id);
            if (req.body.ruolo) np.setRuolo(req.body.ruolo);
            if (req.body.nome) np.setNome(req.body.nome);
            if (req.body.cognome) np.setCognome(req.body.cognome);
            if (req.body.username) np.setUsername(req.body.username);
            if (req.body.password) np.setPassword(req.body.password);
            if (req.body.sede_id) np.setSedeId(req.body.sede_id);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch (e) {
            res.status(500).send ("Internal Server Error");
            // console.log(e);
        }
    }

    static async delete (req, res) {
        try {
            if (await Operatore.delete(req.params.id)) {
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
    OperatoreController
}