const { listOperatore } = require("../dao/operatore.dao");


class Operatore {
    constructor(o) {
        if (o) {
            if (o.id) this.id = o.id;
            if (o.ruolo) this.ruolo = o.ruolo;
            if (o.nome) this.nome = o.nome;
            if (o.cognome) this.cognome = o.cognome;
            if (o.username) this.username = o.username;
            if (o.password) this.password  = o.password;
            if (o.sede_id) this.sede_id  = o.sede_id;
        }
    }

    static async lista () {
        let listOperatoreDAO = await listOperatore();
        let res = [];
        listOperatoreDAO.forEach(element => {
            res.push(new Operatore(element));
        });
        return res;
    }
}

module.exports = {
    Operatore
}