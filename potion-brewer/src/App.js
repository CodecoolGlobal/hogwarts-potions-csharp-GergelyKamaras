import './App.css';
import Students from './Components/Students';
import Potions from './Components/Potions';
import { useEffect, useState } from 'react';

function App() {
    const [studentId, setStudentId] = useState(0);

    function handleStudentChange() {
        let currentStudentId = document.querySelector("#students") == null ? 0 : document.querySelector("#students").value;
        setStudentId(currentStudentId);
        console.log(currentStudentId);
    }

    return (
        <div className="App">
            <h1>Awesome Potion Brewer</h1>
            <Students onChange={handleStudentChange}/>
            <Potions studentId={studentId}/>
        </div>
    );
}

export default App;
