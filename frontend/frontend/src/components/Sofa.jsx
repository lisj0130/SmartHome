import { useGLTF } from '@react-three/drei';

export default function Sofa() {
    const { scene } = useGLTF('/models/sofa.glb'); // VIKTIGT: absolut s�kv�g fr�n public/

    return <primitive object={scene} scale={5} position={[8.5, -1.2, -3]} />;
}
