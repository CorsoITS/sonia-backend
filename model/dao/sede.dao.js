const { getConnection } = require("../../db/connection")

const listSede = async (prenotazioni) => {
    const conn = await getConnection();
    // console.log('trying operatore');
    let query = 'SELECT * FROM sede';
    if (prenotazioni) {
        query="SELECT sede.* , prenotazione.id as pren_id FROM sede left join prenotazione on sede.id = prenotazione.sede_id WHERE prenotazione.id IS NULL";
    }
    const [rows] = await conn.query(query);
    return rows;
}

const insertSede = async (nome, citta, indirizzo) => {
    const conn = await getConnection();
    const query = 'INSERT INTO sede (nome, citta, indirizzo) VALUES (?, ?, ?)';
    const [res] = await conn.query(query, [nome, citta, indirizzo]);
    return res.insertId;
}

const updateSede = async (id, nome, citta, indirizzo) => {
    const conn = await getConnection();
    const query = 'UPDATE sede SET nome = ?, citta = ?, indirizzo = ? WHERE id = ?';
    const [res] = await conn.query(query, [nome, citta, indirizzo, id]);
    return res.affectedRows === 1;
}

const getSedeById = async (id) => {
    const conn = await getConnection();
    const query = 'SELECT * FROM sede WHERE id = ?';
    const [rows] = await conn.query(query, [id]);
    return rows[0];
  }

const deleteSede = async (id) => {
    const conn = await getConnection();
    const query = 'DELETE FROM sede WHERE id = ?';
    const [res] = await conn.query(query, [id]);
    return res.affectedRows === 1;
  }

module.exports = {
    listSede,
    insertSede,
    getSedeById,
    updateSede,
    deleteSede
}