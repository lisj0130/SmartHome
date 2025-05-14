import { useGLTF } from '@react-three/drei';

export default function Tv() {
    const { scene } = useGLTF('/models/tv.gltf'); // VIKTIGT: absolut s�kv�g fr�n public/

    return <primitive object={scene} scale={5} position={[1, 1, 1]} />;
}
