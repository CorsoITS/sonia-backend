const { getConnection } = require("../../db/connection")


const listOperatore = async () => {
    const conn = await getConnection();
    // console.log('trying operatore');
    const query = 'SELECT * FROM operatore';
    const [rows] = await conn.query(query);
    return rows;
}

module.exports = {
    listOperatore
}