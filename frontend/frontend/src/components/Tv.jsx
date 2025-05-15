import { useGLTF } from '@react-three/drei';

export default function Tv() {
    const { scene } = useGLTF('/models/tv.gltf'); // VIKTIGT: absolut sökväg från public/

    return <primitive object={scene} scale={5} position={[-8.8, -0.4, -3]} />;
}
