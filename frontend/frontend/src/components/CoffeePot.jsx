import { useGLTF } from '@react-three/drei';

export default function CoffeePot() {
    const { scene } = useGLTF('/models/pot.glb'); // VIKTIGT: absolut s�kv�g fr�n public/

    return <primitive object={scene} scale={8} position={[4, -0.7, -3]} />;
}
