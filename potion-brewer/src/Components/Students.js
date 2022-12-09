import { useEffect, useState } from "react";
import FetchData from "../Data/BackendCommunication.js";

export default function Students() {
    const [students, setStudents] = useState([]);
    const [isLoading, setLoading] = useState(true);

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
                    <label for="students">Please select a student: </label>
                    <select name="students" id="students">
                        {students.map((student) => {
                            return <option key={student.id} value={student.id}>{student.name}</option>
                        })}
                    </select>
                </form>
            </>
        )
    }
}
