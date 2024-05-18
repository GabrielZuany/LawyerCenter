import { ObjectId } from "mongodb";


export async function getClientController(req: any, res: any) {
    try {
        const db = req.app.db;
        const id = req.params.id;

        if (!id) {
            return res.status(400).json({ message: 'Client ID is required'});
        }

        const result = await db.collection('client').findOne({ _id: new ObjectId(id) });

        if (!result) {
            return res.status(404).json({ message: 'Client not found' });
        }
              
        res.status(200).json(
            {
                message: 'Client found!',
                data: result
            }
        )
        
    } 
    catch (error) {
        console.log(error);
        res.status(500).json({ message: 'Internal server error' });
    }
}