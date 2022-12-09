import { useEffect, useState } from "react";
import FetchData from "../Data/BackendCommunication.js";

export default function Students() {
    const [students, setStudents] = useState([]);
    const [isLoading, setLoading] = useState(true);
    // FetchData("https://localhost:44390/students").then(d => d)
    useEffect(() => {
        async function getStudents () {
            let data = await FetchData("https://localhost:44390/students");
            setStudents(data);
            setLoading(false);
        };
        getStudents();
    }, [])

    if (isLoading)
    {
        return (
            <>
                <p>Loading Student data, please wait</p>
            </>
        )
    }
    else
    {
        return (
            <>
                <form>
                    {students.map((student) => {
                        return <p key={student.id}>{student.name}</p>
                    })}
                </form>
            </>
        )
    }
}
