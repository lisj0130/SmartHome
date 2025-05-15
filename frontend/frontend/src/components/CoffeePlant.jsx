import { useGLTF } from '@react-three/drei';

export default function CoffeePlant() {
    const { scene } = useGLTF('/models/plants.glb'); // VIKTIGT: absolut s�kv�g fr�n public/

    return <primitive object={scene} scale={2.5} position={[4, 0, -3]} />;
}
