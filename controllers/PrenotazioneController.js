const { Prenotazione } = require("../model/models/Prenotazione");

class PrenotazioneController {
    static async lista (req, res) {
        // console.log('trying operatore controller...')
        let result = await Prenotazione.lista();
        return res.json(result);
    }

    static async get (req, res) {
        let result = await Prenotazione.get(req.params.id);
        return res.json(result);
    }

    static async insert (req, res) {
        try {
            let np = new Prenotazione();
            if (req.body.data) np.setData(req.body.data);
            if (req.body.pers_id) np.setPersId(req.body.pers_id);
            if (req.body.sede_id) np.setSedeId(req.body.sede_id);
            await np.save();
            // return res.json({
            //     message: 'done'
            // }); 
            res.status(200).send("Ok");
        } catch (e) {
            res.status(500).send ('Internal Server Error');
            // console.log(e);
        }
    }

    static async update (req, res) {
        try {
            let np = await Prenotazione.get(req.params.id);
            if (req.body.data) np.setData(req.body.data);
            if (req.body.pers_id) np.setPersId(req.body.pers_id);
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
            if (await Prenotazione.delete(req.params.id)) {
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
    PrenotazioneController
}