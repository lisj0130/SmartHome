import { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import { Canvas } from '@react-three/fiber';
import { OrbitControls } from '@react-three/drei';

import FloorWalls from './components/FloorAndWalls';
import Lights from './components/Lights';
import Plants from './components/Plants';
import Sofa from './components/Sofa';
import Tv from './components/Tv';
import TvTable from './components/TvTable';
//import LampTable from './components/LampTable';
import CoffeeTable from './components/CoffeeTable';
import CoffeePlant from './components/CoffeePlant';
import CoffeePot from './components/CoffeePot';
import Rug from './components/Rug';
import Standlight from './components/Standlight';
import Shelf from './components/Shelf';
//import Lamp from './components/Lamp';

function App() {
    const [lampStates, setLampStates] = useState({
        1: true,
        2: true,
        3: true,
    });

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:?") // byt
            .withAutomaticReconnect()
            .build();

        connection.start().then(() => {
            console.log("Ansluten till SignalR");

            connection.on("TurnOnLight", (id) => {
                setLampStates((prev) => ({ ...prev, [id]: true }));
            });

            connection.on("TurnOffLight", (id) => {
                setLampStates((prev) => ({ ...prev, [id]: false }));
            });
        }).catch(err => console.error("Ett fel hittades i anslutningen::", err));

        return () => {
            connection.stop();
        };
    }, []);

    return (
        <Canvas camera={{ position: [0, 10, 5], fov: 75 }}>
            <OrbitControls />
            <FloorWalls />
            {/*<Lights />*/}
            <Lights lampStates={lampStates} />
            <Plants />
            <CoffeePlant />
            <Sofa />
            <TvTable />
            {/*<LampTable />*/}
            {/*<Lamp />*/}
            <Tv />
            <CoffeeTable />
            <CoffeePot />
            <Rug />
            <Standlight />
            <Shelf />
        </Canvas>
    );
}

export default App
