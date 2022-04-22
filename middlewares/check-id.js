const checkId = async (req,res,next) => {
    try {
        if (req.params.id) {
            const eIntero = parseInt(req.params.id);
            if(isNaN(eIntero)) {
              return res.status(400).send("id must be a number");
            }
            let p;
            p = await Persona.get(req.params.id);
            if (p ) {
                req.Persona  = p;
                next();
            }  else {
                return res.status(404).send ("id not found");                    
            }               
        } else {
            return res.status(404).send("sometihng went wrong");
        }
    } catch (err) {
        return res.status(500).send ("Internal Server Error");
    }            
}

module.exports = {
    checkId
}