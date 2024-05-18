

export async function createClientController(req: any, res: any) {
    try {
        const { name, email, password } = req.body;
        const db = req.app.db;

        if (!name || !email || !password) {
            return res.status(400).json({ message: 'Missing fields' });
        }

        const result = await db.collection('client').insertOne({
            name,
            email,
            password
        });
        console.log(result);
        
        if(!result.acknowledged) { throw new Error('Client not created'); }
        
        res.status(201).json({ message: 'Client created' });
        
    } 
    catch (error) {
        console.log(error);
        res.status(500).json({ message: 'Internal server error' });
    }
}