import { Canvas } from '@react-three/fiber';
import { OrbitControls } from '@react-three/drei';
import FloorWalls from './components/FloorAndWalls';
import Lights from './components/Lights';
import Plants from './components/Plants';
import Sofa from './components/Sofa';
import Tv from './components/Tv';
import TvTable from './components/TvTable';
import CoffeeTable from './components/CoffeeTable';
import CoffeePlant from './components/CoffeePlant';
import CoffeePot from './components/CoffeePot';
import Rug from './components/Rug';
import Standlight from './components/Standlight';
import Shelf from './components/Shelf';

function App() {
    return (
        <Canvas camera={{ position: [0, 10, 5], fov: 75 }}>
            <OrbitControls />
            <FloorWalls />
            <Lights />
            <Plants />
            <CoffeePlant />
            <Sofa />
            <TvTable />
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
