const { Operatore } = require("../model/models/Operatore");
const { Persona } = require("../model/models/Persona");
const { Prenotazione } = require("../model/models/Prenotazione");
const { Sede } = require("../model/models/Sede");

const checkIdPersona = async (req,res,next) => {
    try {
        if (req.params.id) {
            const eIntero = parseInt(req.params.id);
            if(isNaN(eIntero)) {
              return res.status(400).send("id must be a number");
            }
            let p;
            p = await Persona.get(req.params.id);
            if (p) {
                req.Persona = p;
                next();
            }  else {
                return res.status(404).send ("id not found");                    
            }               
        } else {
            return res.status(404).send("sometihng went wrong");
        }
    } catch {
        return res.status(500).send ("Internal Server Error");
    }            
}

const checkIdSede = async (req,res,next) => {
    try {
        if (req.params.id) {
            const eIntero = parseInt(req.params.id);
            if(isNaN(eIntero)) {
              return res.status(400).send("id must be a number");
            }
            let p;
            p = await Sede.get(req.params.id);
            if (p) {
                req.Sede = p;
                next();
            }  else {
                return res.status(404).send ("id not found");                    
            }               
        } else {
            return res.status(404).send("sometihng went wrong");
        }
    } catch {
        return res.status(500).send ("Internal Server Error");
    }            
}

const checkIdOperatore = async (req,res,next) => {
    try {
        if (req.params.id) {
            const eIntero = parseInt(req.params.id);
            if(isNaN(eIntero)) {
              return res.status(400).send("id must be a number");
            }
            let p;
            p = await Operatore.get(req.params.id);
            if (p) {
                req.Operatore = p;
                next();
            }  else {
                return res.status(404).send ("id not found");                    
            }               
        } else {
            return res.status(404).send("sometihng went wrong");
        }
    } catch {
        return res.status(500).send ("Internal Server Error");
    }            
}

const checkIdPrenotazione = async (req,res,next) => {
    try {
        if (req.params.id) {
            const eIntero = parseInt(req.params.id);
            if(isNaN(eIntero)) {
              return res.status(400).send("id must be a number");
            }
            let p;
            p = await Prenotazione.get(req.params.id);
            if (p) {
                req.Prenotazione = p;
                next();
            }  else {
                return res.status(404).send ("id not found");                    
            }               
        } else {
            return res.status(404).send("sometihng went wrong");
        }
    } catch {
        return res.status(500).send ("Internal Server Error");
    }            
}

module.exports = {
    checkIdPersona,
    checkIdSede,
    checkIdPrenotazione,
    checkIdOperatore
}