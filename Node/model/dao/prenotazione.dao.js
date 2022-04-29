const { getConnection } = require("../../db/connection")

const listPrenotazione = async () => {
    const conn = await getConnection();
    // console.log('trying operatore');
    let query = `SELECT prenotazione.*, 
    sede.id as sede_id, sede.citta , sede.indirizzo,
    persona.id as pers_id, persona.nome, persona.cognome, persona.codice_fiscale
    FROM prenotazione  
    LEFT JOIN sede ON prenotazione.sede_id = sede.id
    LEFT JOIN persona ON prenotazione.persona_id = persona.id
`;
    const [rows] = await conn.query(query);
    return rows;
}

const insertPrenotazione = async (data, note=null, persona_id, sede_id, somministrazione_id=null) => {
    const conn = await getConnection();
    const query = 'INSERT INTO prenotazione (data, note, persona_id, sede_id, somministrazione_id) VALUES (?, ?, ?, ?, ?)';
    const [res] = await conn.query(query, [data, note, persona_id, sede_id, somministrazione_id]);
    return res.insertId;
}

const updatePrenotazione = async (id, data, note=null, persona_id, sede_id, somministrazione_id=null) => {
    const conn = await getConnection();
    const query = 'UPDATE prenotazione SET data = ?, note = ?, persona_id = ?, sede_id = ?, somministrazione_id = ? WHERE id = ?';
    const [res] = await conn.query(query, [data, note, persona_id, sede_id, somministrazione_id, id]);
    // console.log(res);
    return res.affectedRows === 1;
}

const getPrenotazioneById = async (id) => {
    const conn = await getConnection();
    const query = `SELECT prenotazione.*, 
    sede.id as sede_id, sede.citta , sede.indirizzo,
    persona.id as pers_id, persona.nome, persona.cognome, persona.codice_fiscale
    FROM prenotazione  
    LEFT JOIN sede ON prenotazione.sede_id = sede.id
    LEFT JOIN persona ON prenotazione.persona_id = persona.id
WHERE prenotazione.id = ?`;
    const [rows] = await conn.query(query, [id]);
    return rows[0];
  }

const deletePrenotazione = async (id) => {
    const conn = await getConnection();
    const query = 'DELETE FROM prenotazione WHERE id = ?';
    const [res] = await conn.query(query, [id]);
    return res.affectedRows === 1;
  }

module.exports = {
    listPrenotazione,
    insertPrenotazione,
    getPrenotazioneById,
    updatePrenotazione,
    deletePrenotazione
}