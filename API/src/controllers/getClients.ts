

export async function getClientsController(req: any, res: any) {
    try {
        const db = req.app.db;

        const result = await db.collection('client').find().toArray();
        console.log(result);
              
        res.status(200).json(
            {
                message: 'Clients retrieved',
                data: result
            }
        )
        
    } 
    catch (error) {
        console.log(error);
        res.status(500).json({ message: 'Internal server error' });
    }
}