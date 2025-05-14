import { Canvas } from '@react-three/fiber';
import { OrbitControls } from '@react-three/drei';
import FloorWalls from './components/FloorAndWalls';
import Lights from './components/Lights';
import Plants from './components/Plants';
import Sofa from './components/Sofa';

function App() {
    return (
        <Canvas camera={{ position: [0, 10, 5], fov: 75 }}>
            <OrbitControls />
            <FloorWalls />
            <Lights />
            <Plants />
            <Sofa />
        </Canvas>
    );
}

export default App
