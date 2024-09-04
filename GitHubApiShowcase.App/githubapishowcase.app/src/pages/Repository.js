import { useParams } from "react-router-dom";
import DetailsRepository from "../components/repository/DetailsRepository";

function Repository(){

    let params = useParams();

    return (
            <DetailsRepository owner={params.owner} id={params.id} />
    );
}

export default Repository