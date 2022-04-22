const { listSede, insertSede, getSedeById, updateSede, deleteSede } = require("../dao/sede.dao");

class Sede {
    constructor(p) {
        if (p) {
            if (p.id) this.id = p.id;
            if (p.nome) this.nome = p.nome;
            if (p.citta) this.citta = p.citta;
            if (p.indirizzo) this.indirizzo  = p.indirizzo;
        }
    }

    static async lista () {
        let listSedeDAO = await listSede();
        let res = [];
        listSedeDAO.forEach(element => {
            res.push(new Sede(element));
        });
        return res;
    }

    static async get(id) {
        let pf = await getSedeById(id);
        if (pf) { return new Sede(pf);}
        return null;
    }

    static async delete(id) {
        return await deleteSede(id);
    }

    setId(x) {
    if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
    this.id = x;
    }
    getId() {
        return this.id;
    }

    setNome(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Nome cannot be null';
        this.nome = x;
    }
    getNome() {
        return this.nome;
    }

    setCitta(x) {
        if (x == null || typeof(x) == 'undefined')  throw 'Citta cannot be null';
        this.citta = x;
    }
    getCitta() {
        return this.citta;
    }

    setIndirizzo(x) {
        this.indirizzo = x;

    }
    getIndirizzo() {
        return this.indirizzo;
    }

    async save () {
            if (typeof (this.id) != 'undefined' && this.id != null ) {
                let res = await updateSede (this.id, this.nome, this.citta, this.indirizzo);
                if (! res) throw 'save Sede failed (insert case).'; 
            } else {
                let res = await insertSede (this.nome, this.citta, this.indirizzo);
                this.setId(res);
                if (! res) throw 'save Sede failed (insert case).'; 
        }
    }
}

module.exports = {
    Sede
}